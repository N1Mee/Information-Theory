const textInput = document.getElementById("textInput");
const fileInput = document.getElementById("fileInput");
const passwordInput = document.getElementById("keyInput");
const registerError = document.getElementById("registerError");
const output = document.getElementById("output");
const generateKeyButton = document.getElementById("generateKeyButton");
const lfsrKeyOutput = document.getElementById("lfsrKeyOutput");
const outputKey = document.getElementById("key");
const downloadButton = document.getElementById("downloadButton");
const keyCounter = document.getElementById("keyCounter");
const fileNameSpan = document.getElementById("fileName");
const downloadHint = document.getElementById("downloadHint");

// Variant 11: x^33 + x^13 + 1
// Feedback: new_bit = state[0] XOR state[20]  (0-based from left)
const REGISTER_LENGTH = 33;

// Bytes to show at start AND end when output is too long
const DISPLAY_HALF = 2000;

let currentSourceBytes = new Uint8Array(0);
let encryptedResultBytes = new Uint8Array(0);
let currentFileName = "data.bin";

function validateRegisterInput() {
  const v = passwordInput.value;
  if (v.length === 0) {
    registerError.textContent = "";
    passwordInput.classList.remove("invalid");
    return true;
  }
  if (v.length < REGISTER_LENGTH) {
    registerError.textContent = `Введите ровно ${REGISTER_LENGTH} символов (сейчас ${v.length}).`;
    passwordInput.classList.add("invalid");
    return false;
  }
  registerError.textContent = "";
  passwordInput.classList.remove("invalid");
  return true;
}

passwordInput.addEventListener("input", () => {
  const filtered = passwordInput.value.replace(/[^01]/g, "");
  if (filtered !== passwordInput.value) {
    passwordInput.value = filtered;
  }
  keyCounter.textContent = `${passwordInput.value.length}/${REGISTER_LENGTH}`;
  validateRegisterInput();
});

passwordInput.addEventListener("blur", validateRegisterInput);

function bytesToBitsString(bytes, totalLength = null) {
  if (bytes.length === 0) return "";
  const total = totalLength !== null ? totalLength : bytes.length;

  if (bytes.length <= DISPLAY_HALF * 2) {
    let s = "";
    for (let i = 0; i < bytes.length; i++) {
      s += bytes[i].toString(2).padStart(8, "0") + " ";
    }
    return s.trimEnd();
  }

  let head = "";
  for (let i = 0; i < DISPLAY_HALF; i++) {
    head += bytes[i].toString(2).padStart(8, "0") + " ";
  }

  let tail = "";
  const tailStart = bytes.length - DISPLAY_HALF;
  for (let i = tailStart; i < bytes.length; i++) {
    tail += bytes[i].toString(2).padStart(8, "0") + " ";
  }

  const skipped = total - DISPLAY_HALF * 2;
  return (
    head.trimEnd() +
    `\n\n... [пропущено ${skipped} байт из ${total}] ...\n\n` +
    tail.trimEnd()
  );
}

function resetOutputs() {
  downloadButton.style.display = "none";
  if (downloadHint) downloadHint.style.display = "none";
  lfsrKeyOutput.textContent = "Здесь появятся биты сгенерированного ключа...";
  outputKey.textContent = "Здесь появятся биты результата...";
  encryptedResultBytes = new Uint8Array(0);
}

textInput.addEventListener("input", () => {
  const text = textInput.value;
  const encoder = new TextEncoder();
  currentSourceBytes = encoder.encode(text);
  output.textContent =
    bytesToBitsString(currentSourceBytes) ||
    "Здесь появятся биты исходных данных...";

  // Text is always encrypted → save as .bin.enc so decryption restores .bin
  currentFileName = "encrypted_text.bin.enc";
  resetOutputs();

  if (text.length > 0) fileInput.value = "";
});

fileInput.addEventListener("change", async (event) => {
  const file = event.target.files[0];
  if (!file) return;

  textInput.value = "";
  output.textContent = "Чтение файла...";
  resetOutputs();

  fileNameSpan.textContent = file.name;

  if (file.name.endsWith(".enc")) {
    // Decrypting: strip .enc to reveal original extension
    currentFileName = file.name.replace(/\.enc$/, "");
  } else {
    // Encrypting: append .enc
    currentFileName = file.name + ".enc";
  }

  try {
    const arrayBuffer = await file.arrayBuffer();
    currentSourceBytes = new Uint8Array(arrayBuffer);
    output.textContent = bytesToBitsString(currentSourceBytes);
  } catch (err) {
    output.textContent = "Ошибка при чтении файла: " + err.message;
    currentSourceBytes = new Uint8Array(0);
  }
});

function encrypt(sourceBytes, initialKey) {
  const len = sourceBytes.length;
  const result = new Uint8Array(len);

  const state = Array.from(initialKey, (char) => (char === "1" ? 1 : 0));

  const needFull = len <= DISPLAY_HALF * 2;
  const keyBytesForDisplay = needFull
    ? new Uint8Array(len)
    : new Uint8Array(DISPLAY_HALF * 2);

  for (let i = 0; i < len; i++) {
    let generatedKeyByte = 0;

    for (let b = 0; b < 8; b++) {
      const outputBit = state[0];
      const newBit = state[0] ^ state[20];
      generatedKeyByte |= outputBit << (7 - b);
      state.shift();
      state.push(newBit);
    }

    if (needFull) {
      keyBytesForDisplay[i] = generatedKeyByte;
    } else {
      if (i < DISPLAY_HALF) {
        keyBytesForDisplay[i] = generatedKeyByte;
      } else if (i >= len - DISPLAY_HALF) {
        keyBytesForDisplay[DISPLAY_HALF + (i - (len - DISPLAY_HALF))] = generatedKeyByte;
      }
    }

    result[i] = sourceBytes[i] ^ generatedKeyByte;
  }

  return { result, keyBytesForDisplay, needFull };
}

function keyBytesToBitsString(keyBytesForDisplay, totalLen, needFull) {
  if (needFull) {
    return bytesToBitsString(keyBytesForDisplay, totalLen);
  }

  const head = keyBytesForDisplay.slice(0, DISPLAY_HALF);
  const tail = keyBytesForDisplay.slice(DISPLAY_HALF);

  let headStr = "";
  for (let i = 0; i < head.length; i++) {
    headStr += head[i].toString(2).padStart(8, "0") + " ";
  }

  let tailStr = "";
  for (let i = 0; i < tail.length; i++) {
    tailStr += tail[i].toString(2).padStart(8, "0") + " ";
  }

  const skipped = totalLen - DISPLAY_HALF * 2;
  return (
    headStr.trimEnd() +
    `\n\n... [пропущено ${skipped} байт из ${totalLen}] ...\n\n` +
    tailStr.trimEnd()
  );
}

generateKeyButton.addEventListener("click", () => {
  const key = passwordInput.value;

  if (currentSourceBytes.length === 0) {
    outputKey.textContent = "Сначала введите текст или выберите файл.";
    return;
  }
  if (key.length !== REGISTER_LENGTH) {
    outputKey.textContent = `Ключ должен быть ровно ${REGISTER_LENGTH} символов.`;
    return;
  }

  outputKey.textContent = "Выполнение... Подождите.";
  lfsrKeyOutput.textContent = "Генерация...";
  downloadButton.style.display = "none";
  if (downloadHint) downloadHint.style.display = "none";

  setTimeout(() => {
    const { result, keyBytesForDisplay, needFull } = encrypt(currentSourceBytes, key);
    encryptedResultBytes = result;

    lfsrKeyOutput.textContent = keyBytesToBitsString(
      keyBytesForDisplay,
      currentSourceBytes.length,
      needFull
    );
    outputKey.textContent = bytesToBitsString(encryptedResultBytes);
    downloadButton.style.display = "inline-block";
    if (downloadHint) downloadHint.style.display = "block";
  }, 10);
});

downloadButton.addEventListener("click", async () => {
  if (encryptedResultBytes.length === 0) return;

  const blob = new Blob([encryptedResultBytes], {
    type: "application/octet-stream",
  });

  // Try the File System Access API first (works on HTTPS / localhost in Chrome/Edge).
  if (window.showSaveFilePicker) {
    try {
      const fileHandle = await window.showSaveFilePicker({
        suggestedName: currentFileName,
        types: [
          {
            description: "Бинарный файл",
            accept: { "application/octet-stream": [".*"] },
          },
        ],
      });
      const writable = await fileHandle.createWritable();
      await writable.write(blob);
      await writable.close();
      return;
    } catch (err) {
      if (err.name === "AbortError") return;
      // Fall through to classic download on other errors
    }
  }

  // Fallback: classic anchor download (file goes to default Downloads folder).
  const url = URL.createObjectURL(blob);
  const a = document.createElement("a");
  a.href = url;
  a.download = currentFileName;
  document.body.appendChild(a);
  a.click();
  document.body.removeChild(a);
  URL.revokeObjectURL(url);
});