# BrickingBadStore

A full-stack web application for managing a hierarchical store structure with Cabinets, Groups, and Containers.

## Architecture

### Backend (ASP.NET Core Web API - .NET 9)
- **Framework**: ASP.NET Core Web API with .NET 9
- **Database**: Entity Framework Core with InMemory provider
- **Documentation**: Swagger/OpenAPI
- **Models**: Store → Cabinets → Groups → Containers

### Frontend (React + Redux Toolkit)
- **Framework**: React 19 with Vite
- **State Management**: Redux Toolkit
- **HTTP Client**: Axios
- **UI**: Responsive SPA with tab navigation

## Project Structure

```
BrickingBadStore/
├── BrickingBadStore.Api/          # Backend API (.NET 9)
│   ├── Controllers/               # REST API controllers
│   ├── Models/                    # Entity models
│   ├── DTOs/                      # Data Transfer Objects
│   ├── Data/                      # DbContext and seeding
│   └── Program.cs                 # Application entry point
│
└── BrickingBadStore.Web/          # Frontend React app
    ├── src/
    │   ├── api/                   # Axios configuration
    │   ├── components/            # React components
    │   ├── features/store/        # Redux slice
    │   └── store/                 # Redux store configuration
    └── package.json
```

## Features

### Backend API
- **CRUD Operations** for Containers
- **GET** full store with nested data (Cabinets → Groups → Containers)
- **Seed Data**: Pre-populated with 2 cabinets, 3 groups, and 9 containers
- **CORS** enabled for frontend communication
- **Async/Await** operations throughout

### Frontend UI
- **Store Name Display**: Shows "Bricking Bad Store"
- **Cabinet Tabs**: Navigate between different cabinets
- **Group Borders**: Bold 3px borders around each group
- **Container Cells**: 80x80px cells displaying container IDs
- **Redux Integration**: Uses createAsyncThunk for API calls

## Getting Started

### Prerequisites
- .NET 9 SDK
- Node.js 18+ and npm

### Backend Setup

1. Navigate to the API directory:
```bash
cd BrickingBadStore.Api
```

2. Restore dependencies and build:
```bash
dotnet restore
dotnet build
```

3. Run the API:
```bash
dotnet run --urls "http://localhost:5000"
```

The API will be available at:
- API: http://localhost:5000
- Swagger UI: http://localhost:5000/swagger

### Frontend Setup

1. Navigate to the Web directory:
```bash
cd BrickingBadStore.Web
```

2. Install dependencies:
```bash
npm install
```

3. Start the development server:
```bash
npm run dev
```

The frontend will be available at: http://localhost:3000

### Building for Production

**Backend:**
```bash
cd BrickingBadStore.Api
dotnet publish -c Release
```

**Frontend:**
```bash
cd BrickingBadStore.Web
npm run build
```

## API Endpoints

### Store
- `GET /api/Store` - Get complete store with all nested data

### Containers
- `GET /api/Containers` - Get all containers
- `GET /api/Containers/{id}` - Get container by ID
- `POST /api/Containers` - Create new container
- `PUT /api/Containers/{id}` - Update container
- `DELETE /api/Containers/{id}` - Delete container

## Data Model

```
Store (Id, Name)
  └── Cabinets (Id, Name, StoreId)
       └── Groups (Id, Name, CabinetId)
            └── Containers (Id, Capacity, GroupId)
```

## Technologies Used

### Backend
- ASP.NET Core 9.0
- Entity Framework Core 9.0 (InMemory)
- Swashbuckle.AspNetCore 8.0.0

### Frontend
- React 19.2
- Redux Toolkit 2.11
- Axios 1.13
- Vite 7.3

## Screenshots

### Cabinet A View
Shows Group 1 with 3 containers and Group 2 with 2 containers.

### Cabinet B View
Shows Group 3 with 4 containers.

## License

This project is for demonstration purposes.