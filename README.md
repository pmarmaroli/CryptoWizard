CryptoWizard: AES Encryption & Decryption Made Easy – Command-Line Tool with Key Generation
=============

![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20MacOS%20%7C%20Linux-lightgrey)
![License](https://img.shields.io/badge/license-MIT-green)
![Build](https://img.shields.io/badge/build-passing-brightgreen)

Description
-----------
CryptoWizard is a robust, command-line tool for securely encrypting, decrypting, and managing AES encryption keys. Made for developers, system administrators, and users looking for reliable AES file encryption, CryptoWizard simplifies security tasks with straightforward commands.

Features
--------
- **Encrypt Files**: Encrypt any file, saving the output with a `.enc` extension.
- **Decrypt Files**: Decrypt previously encrypted files to restore the original format.
- **Generate Encryption Keys**: Create AES keys with 128, 192, or 256-bit encryption levels.

Setup and Usage
---------------
Follow these steps to set up and use the CryptoWizard project:

1. **Clone the Repository:**
   Clone the repository to your local machine using the following command:
   ```git clone https://github.com/pmarmaroli/CryptoWizard.git```


    Navigate to the project directory:
    ```cd CryptoWizard```

2. **Open the Project in Visual Studio:**
- Open Visual Studio.
- Select `File` > `Open` > `Project/Solution`.
- Navigate to the `CryptoWizard` directory and open the solution file (`CryptoWizard.sln`).

3. **Build the Project:**
- In Visual Studio, build the solution by selecting `Build` > `Build Solution` or pressing `Ctrl+Shift+B`.

4. **Run the Application:**
- Open a Command Prompt or Terminal.
- Navigate to the output directory of the built executable. For a Debug build, it is typically:

  ```
  cd CryptoWizard\bin\Debug
  ```

5. **Generate an Encryption Key:**
To generate an encryption key, run the executable with the `generatekey` command followed by the key size (128, 192, or 256):
```CryptoWizard.exe generatekey 256```

The generated key will be saved in a file named `encryptionKey.txt` in the root folder.

6. **Encrypt a File:**
To encrypt a file, run the executable with the `encrypt` command, the path to the key file, and the path to the input file:

```CryptoWizard.exe encrypt "config/encryptionKey.txt" "path\to\inputFile.xml" ```

The encrypted file will be saved with a `.enc` extension in the same directory as the input file.

7. **Decrypt a File:**
To decrypt a file, run the executable with the `decrypt` command, the path to the key file, and the path to the encrypted file:

```CryptoWizard.exe decrypt "config/encryptionKey.txt" "path\to\inputFile.xml.enc"```

The decrypted file will be saved with its original extension in the same directory as the encrypted file.

License
-------
This project is licensed under the MIT License.
