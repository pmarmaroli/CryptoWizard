CryptoWizard
=============

Description
-----------
CryptoWizard is a versatile command-line tool for AES file encryption, decryption, and key generation.

Features
--------
- Encrypt Files: Encrypt any file and save the encrypted output with a `.enc` extension.
- Decrypt Files: Decrypt any previously encrypted file and restore the original extension.
- Generate Encryption Keys: Generate AES encryption keys of 128, 192, or 256 bits.

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
- Navigate to the `CryptoWizard` directory and open the solution file (`CryptoWiazrd.sln`).

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
