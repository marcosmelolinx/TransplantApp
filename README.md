# My Project

This project is a full-stack application that utilizes Vue.js with Capacitor for the frontend and ASP.NET Core for the backend.

## Project Structure

```
my-project
├── frontend          # Frontend application using Vue.js
│   ├── src          # Source files for the Vue.js application
│   ├── capacitor.config.ts  # Capacitor configuration
│   ├── package.json  # NPM dependencies and scripts
│   ├── tsconfig.json # TypeScript configuration
│   └── vite.config.ts # Vite configuration for the build tool
└── backend           # Backend application using ASP.NET Core
    ├── Controllers   # Contains API controllers
    ├── Models        # Contains data models
    ├── Program.cs    # Entry point for the ASP.NET Core application
    ├── Startup.cs    # Configures services and request pipeline
    └── appsettings.json # Configuration settings for the ASP.NET Core application
```

## Frontend Setup

1. Navigate to the `frontend` directory:
   ```
   cd frontend
   ```

2. Install dependencies:
   ```
   npm install
   ```

3. Run the development server:
   ```
   npm run dev
   ```

## Backend Setup

1. Navigate to the `backend` directory:
   ```
   cd backend
   ```

2. Restore dependencies:
   ```
   dotnet restore
   ```

3. Run the application:
   ```
   dotnet run
   ```

## Usage

- The frontend application will be available at `http://localhost:3000` (or the port specified in your Vite configuration).
- The backend API will be available at `http://localhost:5000` (or the port specified in your ASP.NET Core configuration).

## License

This project is licensed under the MIT License.