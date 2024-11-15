# Saam Angular & .NET 9 SPA Solution For Technology One

This project is a single-page application (SPA) built with Angular and a backend API developed with .NET 9. It allows users to enter a number, submit it, and receive a response from the backend API that converts the number into words.


## Requirements

1. **Node.js and npm**  
   Install Node.js and npm (Node Package Manager). Visit [Node.js website](https://nodejs.org/) and download the latest version.

2. **.NET SDK**  
   Install the latest version of .NET. Visit [.NET website](https://dotnet.microsoft.com/download) and download the SDK.

3. **Windows Terminal**  
   Install Windows Terminal if it's not already installed. Visit the [Microsoft Store](https://aka.ms/terminal) or download it directly.

## Building and Hosting the Solution

### Steps to Run

1. **Open Windows Terminal**
   - From the Start menu or by searching, open the Windows Terminal application.

2. **Navigate to the Project Directory**
   - In Windows Terminal, change to the root directory of the project:
     ```bash
     cd path\to\your\project
     ```

3. **Run the Start Script**
   - Execute the start script by running the following command:
     ```powershell
     ./start.ps1
     ```
   - This script will handle both the frontend and backend setup, launching the .NET API and Angular application.

4. **Access the Application**
   - Open a browser and navigate to: [http://localhost:4120](http://localhost:4120)

5. **Interact with the Application**
   - In the application, enter a number in the provided input field.
   - Press **Submit** to send your data to the API and receive a response.

---

## Troubleshooting

If you encounter any issues:

- Ensure all prerequisites (Node.js, npm, .NET SDK, and Windows Terminal) are installed correctly.
- Make sure the correct port (4120) is available and not used by another application.
- Check the project’s console output for error messages.

## Additional Information

- This project is configured to run locally on `http://localhost:4120`.
- Backend and frontend are integrated, and updates will reflect immediately after a page refresh if there are any changes in code.

---
