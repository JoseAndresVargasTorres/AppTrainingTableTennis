# 🏓 GUÍA COMPLETA - APLICACIÓN DE TENIS DE MESA EN 7 ETAPAS

## 📋 ÍNDICE DE ETAPAS

1. **Etapa 1**: Instalación y Configuración del Entorno
2. **Etapa 2**: Estructura del Proyecto y Base de Datos
3. **Etapa 3**: Backend API - Fundamentos y CRUD Básico
4. **Etapa 4**: Frontend React - Configuración y Primeros Componentes
5. **Etapa 5**: Integración Frontend-Backend y Funcionalidades Completas
6. **Etapa 6**: Funcionalidades Avanzadas (Rutinas y Historial)
7. **Etapa 7**: Preparación para Cloud y Deployment

---

## 🎯 ETAPA 1: INSTALACIÓN Y CONFIGURACIÓN DEL ENTORNO

### Objetivo
Instalar todas las herramientas necesarias para desarrollo.

### 1.1 FRONTEND - Node.js y Herramientas

**Node.js LTS (Versión 20.x)**
- **Versión recomendada**: Node.js 20.11.0 LTS o superior
- **Link de descarga**: https://nodejs.org/en/download/
- **Instalación**:
  - Descarga el instalador para Windows (.msi)
  - Ejecuta el instalador
  - Marca la opción "Automatically install necessary tools"
  - **Se agrega automáticamente al PATH**

**Verificar instalación**:
```bash
node --version
# Debe mostrar: v20.x.x

npm --version
# Debe mostrar: 10.x.x
```

**Gestor de paquetes: npm vs yarn**
- **Recomendación**: Usa **npm** (viene incluido con Node.js)
- **Razón**: Más simple para aprender, bien mantenido, suficiente para este proyecto
- No necesitas instalar nada adicional

**Herramienta de scaffolding: Vite**
- **Recomendación**: **Vite** (no Create React App)
- **Razones**:
  - ⚡ Mucho más rápido en desarrollo
  - 🔧 Mejor configuración para producción
  - 📦 Bundle size más pequeño
  - 🔥 Hot Module Replacement superior
  - Create React App está en mantenimiento limitado

**Comando para crear proyecto** (lo ejecutarás en Etapa 2):
```bash
npm create vite@latest frontend -- --template react
```

### 1.2 EDITOR DE CÓDIGO - Visual Studio Code

**Descarga**: https://code.visualstudio.com/

**Extensiones ESENCIALES** (instalar desde el marketplace de VS Code):

1. **ESLint** (`dbaeumer.vscode-eslint`)
   - Detecta errores de código JavaScript/React

2. **Prettier - Code formatter** (`esbenp.prettier-vscode`)
   - Formatea código automáticamente

3. **ES7+ React/Redux/React-Native snippets** (`dsznajder.es7-react-js-snippets`)
   - Atajos para crear componentes React rápidamente

4. **C# Dev Kit** (`ms-dotnettools.csdevkit`)
   - Soporte completo para C# (incluye C# base)

5. **REST Client** (`humao.rest-client`)
   - Probar APIs sin Postman

6. **Thunder Client** (`rangav.vscode-thunder-client`)
   - Alternativa visual para probar APIs

7. **GitLens** (`eamodio.gitlens`)
   - Mejora la experiencia con Git

**Configuración de VS Code** (crear archivo `.vscode/settings.json` en tu proyecto):
```json
{
  "editor.formatOnSave": true,
  "editor.defaultFormatter": "esbenp.prettier-vscode",
  "editor.codeActionsOnSave": {
    "source.fixAll.eslint": true
  }
}
```

### 1.3 BACKEND - .NET SDK

**.NET 8 (LTS)**
- **Versión recomendada**: .NET 8.0 (soporte hasta Nov 2026)
- **Link de descarga**: https://dotnet.microsoft.com/download/dotnet/8.0
- Descarga el **SDK** (no solo Runtime)
- **Para Windows**: x64 SDK Installer

**Verificar instalación**:
```bash
dotnet --version
# Debe mostrar: 8.0.x
```

**¿Necesito .NET Runtime por separado?**
- **NO**, el SDK incluye el Runtime

**IDE recomendado: Visual Studio Code**
- **Razón**: Ya lo tienes instalado, es más ligero, y con C# Dev Kit tiene todas las capacidades necesarias
- Visual Studio 2022 Community es muy pesado para este proyecto inicial

### 1.4 BASE DE DATOS - SQL Server

**SQL Server 2022 Developer Edition**
- **Recomendación**: Developer Edition (GRATIS, todas las funcionalidades)
- **Link**: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
- Click en "Download now" bajo "Developer"
- Durante instalación:
  - Tipo: "Basic" (más simple para empezar)
  - Acepta ubicación por defecto

**Authentication Mode**:
- **Recomendación para desarrollo y producción**: **Mixed Mode**
- Durante instalación, configura:
  - Username: `sa`
  - Password: `YourStrongP@ssw0rd!` (usa una contraseña fuerte)

**SQL Server Management Studio (SSMS)**
- **Link**: https://aka.ms/ssmsfullsetup
- **Instalación**: Ejecuta el instalador (descarga automática ~600MB)
- **¿Es obligatorio?**: No, pero **muy recomendado** para aprender SQL
- **Alternativa**: Azure Data Studio (más moderno, pero menos completo)

**Recomendación**: Instala SSMS para empezar, puedes agregar Azure Data Studio después.

### 1.5 Herramientas de Desarrollo Adicionales

**Git para Windows**
- **Link**: https://git-scm.com/download/win
- Acepta opciones por defecto

**React Developer Tools**
- Extensión de navegador (Chrome/Edge)
- **Chrome**: https://chrome.google.com/webstore/detail/react-developer-tools/fmkadmapgofadopljbjfkapdkoienihi
- **Edge**: Buscar "React Developer Tools" en Microsoft Edge Add-ons

### 1.6 Verificación Final

Abre PowerShell o Command Prompt y verifica:

```bash
node --version        # ✅ v20.x.x
npm --version         # ✅ 10.x.x
dotnet --version      # ✅ 8.0.x
git --version         # ✅ 2.x.x
```

**¿SQL Server está corriendo?**
```bash
# En PowerShell
Get-Service -Name MSSQLSERVER
# Debe mostrar Status: Running
```

---

## ✅ CHECKPOINT ETAPA 1

Antes de continuar a la Etapa 2, verifica:
- ✅ Node.js y npm instalados
- ✅ VS Code con todas las extensiones
- ✅ .NET 8 SDK instalado
- ✅ SQL Server 2022 corriendo
- ✅ SSMS instalado
- ✅ Git instalado

---

## 🏗️ ETAPA 2: ESTRUCTURA DEL PROYECTO Y BASE DE DATOS

### Objetivo
Crear la estructura de carpetas, inicializar proyectos y diseñar la base de datos.

### 2.1 DECISIÓN: Monorepo vs Repositorios Separados

**Recomendación: MONOREPO**

**Ventajas**:
- ✅ Un solo `git clone`
- ✅ Versionado sincronizado frontend-backend
- ✅ Más fácil para proyectos pequeños/medianos
- ✅ Compartir configuraciones (ESLint, Prettier)

**Desventajas**:
- ❌ Deployment requiere separar carpetas
- ❌ CI/CD necesita configuración adicional

Para este proyecto de aprendizaje, **monorepo es ideal**.

### 2.2 CREAR ESTRUCTURA DE DIRECTORIOS

**Paso 1**: Crear carpeta raíz
```bash
# En tu ubicación de proyectos
cd C:\Users\josev\OneDrive\Documentos
mkdir AppTrainingTableTennis
cd AppTrainingTableTennis
```

**Paso 2**: Inicializar Git
```bash
git init
```

**Paso 3**: Crear estructura completa
```bash
# Crear carpetas principales
mkdir frontend
mkdir backend
mkdir database
mkdir docs
```

### 2.3 ESTRUCTURA FINAL DEL PROYECTO

```
AppTrainingTableTennis/
│
├── frontend/                          # Aplicación React (Vite)
│   ├── public/                        # Archivos estáticos
│   ├── src/
│   │   ├── components/               # Componentes reutilizables
│   │   │   ├── common/               # Botones, inputs, modales
│   │   │   ├── exercises/            # Componentes de ejercicios
│   │   │   └── routines/             # Componentes de rutinas
│   │   ├── pages/                    # Páginas/Vistas principales
│   │   │   ├── ExercisesPage.jsx
│   │   │   ├── RoutinesPage.jsx
│   │   │   └── HistoryPage.jsx
│   │   ├── services/                 # Llamadas a la API
│   │   │   └── api.js
│   │   ├── hooks/                    # Custom React Hooks
│   │   ├── utils/                    # Funciones auxiliares
│   │   ├── styles/                   # CSS/SCSS global
│   │   ├── App.jsx
│   │   └── main.jsx
│   ├── .env.development
│   ├── .env.production
│   ├── .gitignore
│   ├── package.json
│   ├── vite.config.js
│   └── index.html
│
├── backend/                           # API .NET 8
│   ├── Controllers/                  # Endpoints de la API
│   │   ├── ExercisesController.cs
│   │   ├── RoutinesController.cs
│   │   └── TrainingHistoryController.cs
│   ├── Models/                       # Entidades de la BD
│   │   ├── Exercise.cs
│   │   ├── Routine.cs
│   │   ├── RoutineExercise.cs
│   │   └── TrainingHistory.cs
│   ├── Data/                         # DbContext y configuraciones EF
│   │   ├── AppDbContext.cs
│   │   └── Configurations/           # Fluent API configs
│   ├── DTOs/                         # Data Transfer Objects
│   │   ├── ExerciseDto.cs
│   │   └── RoutineDto.cs
│   ├── Services/                     # Lógica de negocio
│   │   ├── Interfaces/
│   │   │   └── IExerciseService.cs
│   │   └── ExerciseService.cs
│   ├── Repositories/                 # Acceso a datos (opcional)
│   │   ├── Interfaces/
│   │   └── ExerciseRepository.cs
│   ├── Migrations/                   # Migraciones EF (auto-generadas)
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── Program.cs
│   └── TableTennisApi.csproj
│
├── database/
│   ├── scripts/                      # Scripts SQL opcionales
│   │   └── seed-data.sql             # Datos iniciales
│   └── diagram/                      # Diagramas ER
│
├── docs/
│   ├── api-documentation.md
│   └── deployment-guide.md
│
├── .gitignore                        # Git ignore global
├── README.md
└── docker-compose.yml                # (Etapa 7)
```

### 2.4 CREAR PROYECTO FRONTEND

```bash
cd frontend
npm create vite@latest . -- --template react

# Instalar dependencias
npm install

# Instalar librerías adicionales
npm install axios react-router-dom

# Librerías opcionales (recomendadas)
npm install react-hook-form          # Manejo de formularios
npm install @tanstack/react-query    # Cache y estado de server
npm install lucide-react             # Iconos modernos
```

**Estructura de carpetas dentro de src**:
```bash
cd src
mkdir components pages services hooks utils styles
cd components
mkdir common exercises routines
```

### 2.5 CREAR PROYECTO BACKEND

```bash
cd ../../backend

# Crear Web API
dotnet new webapi -n TableTennisApi

# Esto crea una carpeta TableTennisApi, mover contenido a backend
cd TableTennisApi
move * ..
cd ..
rmdir TableTennisApi

# Instalar Entity Framework Core
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0

# Swagger (ya viene incluido en template webapi)
# CORS (configuraremos en código)
```

**Crear carpetas adicionales**:
```bash
mkdir Models
mkdir Data
mkdir DTOs
mkdir Services
mkdir Services\Interfaces
mkdir Repositories
mkdir Repositories\Interfaces
mkdir Data\Configurations
```

### 2.6 DISEÑO DE LA BASE DE DATOS

**Modelo de Datos - 4 Tablas Principales**

```
┌─────────────────────────────────────┐
│          Exercises                  │
├─────────────────────────────────────┤
│ Id (PK)              INT            │
│ Name                 NVARCHAR(200)  │
│ Description          NVARCHAR(MAX)  │
│ Category             NVARCHAR(100)  │
│ DurationMinutes      INT            │
│ DifficultyLevel      NVARCHAR(50)   │
│ AdditionalNotes      NVARCHAR(MAX)  │
│ CreatedAt            DATETIME2      │
│ UpdatedAt            DATETIME2      │
└─────────────────────────────────────┘
          │
          │ 1:N
          ▼
┌─────────────────────────────────────┐
│      RoutineExercises               │
├─────────────────────────────────────┤
│ Id (PK)              INT            │
│ RoutineId (FK)       INT            │
│ ExerciseId (FK)      INT            │
│ OrderIndex           INT            │
│ CustomDuration       INT (nullable) │
│ Notes                NVARCHAR(500)  │
└─────────────────────────────────────┘
          ▲
          │ N:1
          │
┌─────────────────────────────────────┐
│          Routines                   │
├─────────────────────────────────────┤
│ Id (PK)              INT            │
│ Name                 NVARCHAR(200)  │
│ Description          NVARCHAR(MAX)  │
│ TotalDuration        INT            │
│ CreatedAt            DATETIME2      │
│ UpdatedAt            DATETIME2      │
└─────────────────────────────────────┘
          │
          │ 1:N
          ▼
┌─────────────────────────────────────┐
│      TrainingHistory                │
├─────────────────────────────────────┤
│ Id (PK)              INT            │
│ RoutineId (FK)       INT            │
│ TrainingDate         DATETIME2      │
│ CompletedDuration    INT            │
│ Notes                NVARCHAR(MAX)  │
│ Rating               INT (1-5)      │
└─────────────────────────────────────┘
```

**Categorías de Ejercicios** (enum o valores fijos):
1. Calentamiento
2. Entrenamiento Inicial
3. Ejercicios de Movilidad Avanzada
4. Ejercicios Inconsistentes
5. Ejercicios Enfocados en Situaciones de Partido

**Niveles de Dificultad**:
- Principiante
- Intermedio
- Avanzado

### 2.7 CREAR .gitignore

```bash
# En la raíz del proyecto
code .gitignore
```

**Contenido del .gitignore**:
```gitignore
# Frontend (Node.js / React)
frontend/node_modules/
frontend/dist/
frontend/build/
frontend/.env
frontend/.env.local
frontend/.env.development.local
frontend/.env.production.local
frontend/npm-debug.log*
frontend/yarn-debug.log*
frontend/yarn-error.log*

# Backend (.NET)
backend/bin/
backend/obj/
backend/*.user
backend/*.suo
backend/.vs/
backend/appsettings.Development.json
backend/appsettings.Local.json

# Base de datos
*.mdf
*.ldf
*.bak

# IDEs
.vscode/
.idea/
*.swp
*.swo

# OS
.DS_Store
Thumbs.db

# Logs
*.log

# Secrets
*.secret
*.key
```

### 2.8 CREAR README.md

```bash
code README.md
```

**Contenido básico**:
```markdown
# 🏓 Aplicación de Entrenamiento de Tenis de Mesa

Aplicación web full-stack para gestionar ejercicios y rutinas de entrenamiento de tenis de mesa.

## 🛠️ Stack Tecnológico

- **Frontend**: React 18 + Vite
- **Backend**: .NET 8 Web API
- **Base de Datos**: SQL Server 2022
- **Cloud**: Google Cloud Platform (futuro)

## 📦 Instalación

### Frontend
```bash
cd frontend
npm install
npm run dev
```

### Backend
```bash
cd backend
dotnet restore
dotnet run
```

## 📖 Documentación

Ver carpeta `docs/` para documentación detallada.
```

### 2.9 CREAR BASE DE DATOS EN SQL SERVER

**Opción 1: SSMS (Manual)**
1. Abrir SQL Server Management Studio
2. Conectar a `localhost` (o `.\SQLEXPRESS` si instalaste Express)
3. Click derecho en "Databases" → New Database
4. Nombre: `TableTennisTrainingDB`
5. Click OK

**Opción 2: Entity Framework (Recomendado)**
- Lo haremos en Etapa 3 con Code-First Migrations

---

## ✅ CHECKPOINT ETAPA 2

- ✅ Estructura de carpetas creada
- ✅ Proyecto React (Vite) inicializado
- ✅ Proyecto .NET Web API creado
- ✅ Paquetes NuGet instalados
- ✅ Git inicializado con .gitignore
- ✅ Base de datos creada (o lista para migrations)

---

## 🔧 ETAPA 3: BACKEND API - FUNDAMENTOS Y CRUD BÁSICO

### Objetivo
Crear el backend con Entity Framework, implementar modelos y el CRUD de ejercicios.

### 3.1 CONFIGURAR CONNECTION STRING

**Editar `appsettings.Development.json`**:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TableTennisTrainingDB;User Id=sa;Password=YourStrongP@ssw0rd!;TrustServerCertificate=True;"
  }
}
```

**⚠️ IMPORTANTE**: Reemplaza `YourStrongP@ssw0rd!` con tu contraseña de SQL Server.

**Para Windows Authentication** (si configuraste SQL Server con Windows Auth):
```json
"DefaultConnection": "Server=localhost;Database=TableTennisTrainingDB;Integrated Security=True;TrustServerCertificate=True;"
```

### 3.2 CREAR MODELOS (Models/)

**Models/Exercise.cs**:
```csharp
namespace TableTennisApi.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public string DifficultyLevel { get; set; } = string.Empty;
        public string? AdditionalNotes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Relaciones
        public ICollection<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();
    }
}
```

**Models/Routine.cs**:
```csharp
namespace TableTennisApi.Models
{
    public class Routine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TotalDuration { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Relaciones
        public ICollection<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();
        public ICollection<TrainingHistory> TrainingHistories { get; set; } = new List<TrainingHistory>();
    }
}
```

**Models/RoutineExercise.cs**:
```csharp
namespace TableTennisApi.Models
{
    public class RoutineExercise
    {
        public int Id { get; set; }
        public int RoutineId { get; set; }
        public int ExerciseId { get; set; }
        public int OrderIndex { get; set; }
        public int? CustomDuration { get; set; }
        public string? Notes { get; set; }

        // Navegación
        public Routine Routine { get; set; } = null!;
        public Exercise Exercise { get; set; } = null!;
    }
}
```

**Models/TrainingHistory.cs**:
```csharp
namespace TableTennisApi.Models
{
    public class TrainingHistory
    {
        public int Id { get; set; }
        public int RoutineId { get; set; }
        public DateTime TrainingDate { get; set; }
        public int CompletedDuration { get; set; }
        public string? Notes { get; set; }
        public int Rating { get; set; } // 1-5

        // Navegación
        public Routine Routine { get; set; } = null!;
    }
}
```

### 3.3 CREAR DbContext (Data/AppDbContext.cs)

```csharp
using Microsoft.EntityFrameworkCore;
using TableTennisApi.Models;

namespace TableTennisApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<RoutineExercise> RoutineExercises { get; set; }
        public DbSet<TrainingHistory> TrainingHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Exercise
            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DifficultyLevel).IsRequired().HasMaxLength(50);
            });

            // Configuración de Routine
            modelBuilder.Entity<Routine>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired().HasMaxLength(200);
            });

            // Configuración de RoutineExercise (tabla intermedia)
            modelBuilder.Entity<RoutineExercise>(entity =>
            {
                entity.HasKey(re => re.Id);

                entity.HasOne(re => re.Routine)
                    .WithMany(r => r.RoutineExercises)
                    .HasForeignKey(re => re.RoutineId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(re => re.Exercise)
                    .WithMany(e => e.RoutineExercises)
                    .HasForeignKey(re => re.ExerciseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de TrainingHistory
            modelBuilder.Entity<TrainingHistory>(entity =>
            {
                entity.HasKey(th => th.Id);

                entity.HasOne(th => th.Routine)
                    .WithMany(r => r.TrainingHistories)
                    .HasForeignKey(th => th.RoutineId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
```

### 3.4 CONFIGURAR Program.cs

**Editar `Program.cs`** (reemplazar todo el contenido):

```csharp
using Microsoft.EntityFrameworkCore;
using TableTennisApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar Entity Framework con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar CORS para React
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();

app.Run();
```

### 3.5 CREAR Y APLICAR MIGRACIONES

**En terminal dentro de la carpeta `backend`**:

```bash
# Instalar herramienta EF (solo primera vez)
dotnet tool install --global dotnet-ef

# Crear primera migración
dotnet ef migrations add InitialCreate

# Aplicar migración a la base de datos
dotnet ef database update
```

**Verificar en SSMS**:
- Conectar a SQL Server
- Expandir `TableTennisTrainingDB`
- Deberías ver las 4 tablas creadas

### 3.6 CREAR DTOs (Data Transfer Objects)

**DTOs/ExerciseDto.cs**:
```csharp
namespace TableTennisApi.DTOs
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public string DifficultyLevel { get; set; } = string.Empty;
        public string? AdditionalNotes { get; set; }
    }

    public class CreateExerciseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public string DifficultyLevel { get; set; } = string.Empty;
        public string? AdditionalNotes { get; set; }
    }

    public class UpdateExerciseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public string DifficultyLevel { get; set; } = string.Empty;
        public string? AdditionalNotes { get; set; }
    }
}
```

### 3.7 CREAR CONTROLLER DE EJERCICIOS

**Controllers/ExercisesController.cs**:

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableTennisApi.Data;
using TableTennisApi.DTOs;
using TableTennisApi.Models;

namespace TableTennisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExercisesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseDto>>> GetExercises(
            [FromQuery] string? category = null,
            [FromQuery] string? difficulty = null)
        {
            var query = _context.Exercises.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(e => e.Category == category);
            }

            if (!string.IsNullOrEmpty(difficulty))
            {
                query = query.Where(e => e.DifficultyLevel == difficulty);
            }

            var exercises = await query
                .Select(e => new ExerciseDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Category = e.Category,
                    DurationMinutes = e.DurationMinutes,
                    DifficultyLevel = e.DifficultyLevel,
                    AdditionalNotes = e.AdditionalNotes
                })
                .ToListAsync();

            return Ok(exercises);
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseDto>> GetExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            var exerciseDto = new ExerciseDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                Category = exercise.Category,
                DurationMinutes = exercise.DurationMinutes,
                DifficultyLevel = exercise.DifficultyLevel,
                AdditionalNotes = exercise.AdditionalNotes
            };

            return Ok(exerciseDto);
        }

        // POST: api/Exercises
        [HttpPost]
        public async Task<ActionResult<ExerciseDto>> CreateExercise(CreateExerciseDto createDto)
        {
            var exercise = new Exercise
            {
                Name = createDto.Name,
                Description = createDto.Description,
                Category = createDto.Category,
                DurationMinutes = createDto.DurationMinutes,
                DifficultyLevel = createDto.DifficultyLevel,
                AdditionalNotes = createDto.AdditionalNotes,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();

            var exerciseDto = new ExerciseDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                Category = exercise.Category,
                DurationMinutes = exercise.DurationMinutes,
                DifficultyLevel = exercise.DifficultyLevel,
                AdditionalNotes = exercise.AdditionalNotes
            };

            return CreatedAtAction(nameof(GetExercise), new { id = exercise.Id }, exerciseDto);
        }

        // PUT: api/Exercises/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(int id, UpdateExerciseDto updateDto)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            exercise.Name = updateDto.Name;
            exercise.Description = updateDto.Description;
            exercise.Category = updateDto.Category;
            exercise.DurationMinutes = updateDto.DurationMinutes;
            exercise.DifficultyLevel = updateDto.DifficultyLevel;
            exercise.AdditionalNotes = updateDto.AdditionalNotes;
            exercise.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Exercises/categories
        [HttpGet("categories")]
        public ActionResult<IEnumerable<string>> GetCategories()
        {
            var categories = new List<string>
            {
                "Calentamiento",
                "Entrenamiento Inicial",
                "Ejercicios de Movilidad Avanzada",
                "Ejercicios Inconsistentes",
                "Ejercicios Enfocados en Situaciones de Partido"
            };

            return Ok(categories);
        }

        // GET: api/Exercises/difficulties
        [HttpGet("difficulties")]
        public ActionResult<IEnumerable<string>> GetDifficulties()
        {
            var difficulties = new List<string>
            {
                "Principiante",
                "Intermedio",
                "Avanzado"
            };

            return Ok(difficulties);
        }
    }
}
```

### 3.8 PROBAR LA API

**Ejecutar el backend**:
```bash
cd backend
dotnet run
```

**Abrir Swagger**: https://localhost:7xxx/swagger (el puerto aparece en la consola)

**Probar endpoints**:
1. POST /api/Exercises - Crear ejercicio
2. GET /api/Exercises - Listar todos
3. GET /api/Exercises/1 - Obtener por ID
4. PUT /api/Exercises/1 - Actualizar
5. DELETE /api/Exercises/1 - Eliminar

**Ejemplo de JSON para crear ejercicio**:
```json
{
  "name": "Saque con efecto lateral",
  "description": "Practicar saques con efecto lateral para descolocar al oponente",
  "category": "Entrenamiento Inicial",
  "durationMinutes": 15,
  "difficultyLevel": "Intermedio",
  "additionalNotes": "Alternar entre efecto derecho e izquierdo"
}
```

---

## ✅ CHECKPOINT ETAPA 3

- ✅ Modelos creados
- ✅ DbContext configurado
- ✅ Migraciones aplicadas
- ✅ Base de datos creada con tablas
- ✅ Controller de Ejercicios funcionando
- ✅ CRUD completo probado en Swagger

---

## ⚛️ ETAPA 4: FRONTEND REACT - CONFIGURACIÓN Y PRIMEROS COMPONENTES

### Objetivo
Configurar React, crear componentes básicos y conectar con el backend.

### 4.1 CONFIGURAR VARIABLES DE ENTORNO

**frontend/.env.development**:
```env
VITE_API_URL=https://localhost:7xxx
```

**⚠️ Reemplaza** `7xxx` con el puerto de tu backend (lo ves al ejecutar `dotnet run`).

**frontend/.env.production**:
```env
VITE_API_URL=https://your-production-api.com
```

### 4.2 CONFIGURAR AXIOS (services/api.js)

**frontend/src/services/api.js**:
```javascript
import axios from 'axios';

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Interceptor para manejo de errores
api.interceptors.response.use(
  (response) => response,
  (error) => {
    console.error('API Error:', error.response?.data || error.message);
    return Promise.reject(error);
  }
);

// Ejercicios
export const exerciseService = {
  getAll: (params) => api.get('/api/exercises', { params }),
  getById: (id) => api.get(`/api/exercises/${id}`),
  create: (data) => api.post('/api/exercises', data),
  update: (id, data) => api.put(`/api/exercises/${id}`, data),
  delete: (id) => api.delete(`/api/exercises/${id}`),
  getCategories: () => api.get('/api/exercises/categories'),
  getDifficulties: () => api.get('/api/exercises/difficulties'),
};

export default api;
```

### 4.3 INSTALAR Y CONFIGURAR REACT ROUTER

**Ya instalado**, ahora configurar:

**frontend/src/main.jsx**:
```jsx
import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter } from 'react-router-dom'
import App from './App.jsx'
import './index.css'

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </React.StrictMode>,
)
```

### 4.4 CREAR LAYOUT Y NAVEGACIÓN

**frontend/src/App.jsx**:
```jsx
import { Routes, Route } from 'react-router-dom';
import Layout from './components/common/Layout';
import ExercisesPage from './pages/ExercisesPage';
import RoutinesPage from './pages/RoutinesPage';
import HistoryPage from './pages/HistoryPage';
import './App.css';

function App() {
  return (
    <Layout>
      <Routes>
        <Route path="/" element={<ExercisesPage />} />
        <Route path="/exercises" element={<ExercisesPage />} />
        <Route path="/routines" element={<RoutinesPage />} />
        <Route path="/history" element={<HistoryPage />} />
      </Routes>
    </Layout>
  );
}

export default App;
```

**frontend/src/components/common/Layout.jsx**:
```jsx
import { Link, useLocation } from 'react-router-dom';
import './Layout.css';

function Layout({ children }) {
  const location = useLocation();

  const navItems = [
    { path: '/exercises', label: 'Ejercicios' },
    { path: '/routines', label: 'Rutinas' },
    { path: '/history', label: 'Historial' },
  ];

  return (
    <div className="layout">
      <header className="header">
        <div className="header-content">
          <h1>🏓 Entrenamiento Tenis de Mesa</h1>
          <nav className="nav">
            {navItems.map((item) => (
              <Link
                key={item.path}
                to={item.path}
                className={`nav-link ${location.pathname === item.path ? 'active' : ''}`}
              >
                {item.label}
              </Link>
            ))}
          </nav>
        </div>
      </header>
      <main className="main-content">{children}</main>
      <footer className="footer">
        <p>© 2025 Aplicación de Entrenamiento de Tenis de Mesa</p>
      </footer>
    </div>
  );
}

export default Layout;
```

**frontend/src/components/common/Layout.css**:
```css
.layout {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}

.header {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  padding: 1rem 0;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.header-content {
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 2rem;
}

.header h1 {
  margin: 0 0 1rem 0;
  font-size: 1.8rem;
}

.nav {
  display: flex;
  gap: 1.5rem;
}

.nav-link {
  color: white;
  text-decoration: none;
  padding: 0.5rem 1rem;
  border-radius: 4px;
  transition: background-color 0.3s;
}

.nav-link:hover {
  background-color: rgba(255, 255, 255, 0.2);
}

.nav-link.active {
  background-color: rgba(255, 255, 255, 0.3);
  font-weight: bold;
}

.main-content {
  flex: 1;
  max-width: 1200px;
  width: 100%;
  margin: 2rem auto;
  padding: 0 2rem;
}

.footer {
  background-color: #f5f5f5;
  text-align: center;
  padding: 1rem;
  margin-top: 2rem;
}
```

### 4.5 CREAR PÁGINA DE EJERCICIOS (BÁSICA)

**frontend/src/pages/ExercisesPage.jsx**:
```jsx
import { useState, useEffect } from 'react';
import { exerciseService } from '../services/api';
import './ExercisesPage.css';

function ExercisesPage() {
  const [exercises, setExercises] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [selectedCategory, setSelectedCategory] = useState('');
  const [selectedDifficulty, setSelectedDifficulty] = useState('');
  const [categories, setCategories] = useState([]);
  const [difficulties, setDifficulties] = useState([]);

  useEffect(() => {
    loadCategories();
    loadDifficulties();
    loadExercises();
  }, [selectedCategory, selectedDifficulty]);

  const loadCategories = async () => {
    try {
      const response = await exerciseService.getCategories();
      setCategories(response.data);
    } catch (err) {
      console.error('Error loading categories:', err);
    }
  };

  const loadDifficulties = async () => {
    try {
      const response = await exerciseService.getDifficulties();
      setDifficulties(response.data);
    } catch (err) {
      console.error('Error loading difficulties:', err);
    }
  };

  const loadExercises = async () => {
    try {
      setLoading(true);
      const params = {};
      if (selectedCategory) params.category = selectedCategory;
      if (selectedDifficulty) params.difficulty = selectedDifficulty;

      const response = await exerciseService.getAll(params);
      setExercises(response.data);
      setError(null);
    } catch (err) {
      setError('Error al cargar ejercicios');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm('¿Estás seguro de eliminar este ejercicio?')) {
      try {
        await exerciseService.delete(id);
        loadExercises();
      } catch (err) {
        alert('Error al eliminar ejercicio');
      }
    }
  };

  if (loading) return <div className="loading">Cargando ejercicios...</div>;
  if (error) return <div className="error">{error}</div>;

  return (
    <div className="exercises-page">
      <div className="page-header">
        <h2>Ejercicios de Entrenamiento</h2>
        <button className="btn btn-primary">+ Nuevo Ejercicio</button>
      </div>

      <div className="filters">
        <select
          value={selectedCategory}
          onChange={(e) => setSelectedCategory(e.target.value)}
          className="filter-select"
        >
          <option value="">Todas las categorías</option>
          {categories.map((cat) => (
            <option key={cat} value={cat}>
              {cat}
            </option>
          ))}
        </select>

        <select
          value={selectedDifficulty}
          onChange={(e) => setSelectedDifficulty(e.target.value)}
          className="filter-select"
        >
          <option value="">Todos los niveles</option>
          {difficulties.map((diff) => (
            <option key={diff} value={diff}>
              {diff}
            </option>
          ))}
        </select>
      </div>

      <div className="exercises-grid">
        {exercises.length === 0 ? (
          <p className="no-data">No hay ejercicios disponibles</p>
        ) : (
          exercises.map((exercise) => (
            <div key={exercise.id} className="exercise-card">
              <div className="exercise-header">
                <h3>{exercise.name}</h3>
                <span className={`badge badge-${exercise.difficultyLevel.toLowerCase()}`}>
                  {exercise.difficultyLevel}
                </span>
              </div>
              <p className="exercise-description">{exercise.description}</p>
              <div className="exercise-meta">
                <span className="category">{exercise.category}</span>
                <span className="duration">{exercise.durationMinutes} min</span>
              </div>
              {exercise.additionalNotes && (
                <p className="notes">📝 {exercise.additionalNotes}</p>
              )}
              <div className="exercise-actions">
                <button className="btn btn-secondary">Editar</button>
                <button
                  className="btn btn-danger"
                  onClick={() => handleDelete(exercise.id)}
                >
                  Eliminar
                </button>
              </div>
            </div>
          ))
        )}
      </div>
    </div>
  );
}

export default ExercisesPage;
```

**frontend/src/pages/ExercisesPage.css**:
```css
.exercises-page {
  animation: fadeIn 0.3s;
}

@keyframes fadeIn {
  from { opacity: 0; }
  to { opacity: 1; }
}

.page-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 2rem;
}

.page-header h2 {
  margin: 0;
  color: #333;
}

.filters {
  display: flex;
  gap: 1rem;
  margin-bottom: 2rem;
}

.filter-select {
  padding: 0.5rem 1rem;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 1rem;
  min-width: 200px;
}

.exercises-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(350px, 1fr));
  gap: 1.5rem;
}

.exercise-card {
  background: white;
  border-radius: 8px;
  padding: 1.5rem;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
  transition: transform 0.2s, box-shadow 0.2s;
}

.exercise-card:hover {
  transform: translateY(-4px);
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
}

.exercise-header {
  display: flex;
  justify-content: space-between;
  align-items: start;
  margin-bottom: 1rem;
}

.exercise-header h3 {
  margin: 0;
  font-size: 1.2rem;
  color: #333;
}

.badge {
  padding: 0.25rem 0.75rem;
  border-radius: 12px;
  font-size: 0.85rem;
  font-weight: bold;
}

.badge-principiante {
  background-color: #d4edda;
  color: #155724;
}

.badge-intermedio {
  background-color: #fff3cd;
  color: #856404;
}

.badge-avanzado {
  background-color: #f8d7da;
  color: #721c24;
}

.exercise-description {
  color: #666;
  line-height: 1.5;
  margin-bottom: 1rem;
}

.exercise-meta {
  display: flex;
  justify-content: space-between;
  margin-bottom: 0.5rem;
  font-size: 0.9rem;
}

.category {
  color: #667eea;
  font-weight: 500;
}

.duration {
  color: #999;
}

.notes {
  background-color: #f8f9fa;
  padding: 0.5rem;
  border-radius: 4px;
  font-size: 0.9rem;
  color: #555;
  margin: 0.5rem 0;
}

.exercise-actions {
  display: flex;
  gap: 0.5rem;
  margin-top: 1rem;
}

.btn {
  padding: 0.5rem 1rem;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 0.9rem;
  transition: background-color 0.2s;
}

.btn-primary {
  background-color: #667eea;
  color: white;
}

.btn-primary:hover {
  background-color: #5568d3;
}

.btn-secondary {
  background-color: #6c757d;
  color: white;
}

.btn-secondary:hover {
  background-color: #5a6268;
}

.btn-danger {
  background-color: #dc3545;
  color: white;
}

.btn-danger:hover {
  background-color: #c82333;
}

.loading, .error, .no-data {
  text-align: center;
  padding: 2rem;
  font-size: 1.1rem;
  color: #666;
}

.error {
  color: #dc3545;
}
```

### 4.6 CREAR PÁGINAS PLACEHOLDER

**frontend/src/pages/RoutinesPage.jsx**:
```jsx
function RoutinesPage() {
  return (
    <div>
      <h2>Rutinas de Entrenamiento</h2>
      <p>Funcionalidad en desarrollo - Etapa 6</p>
    </div>
  );
}

export default RoutinesPage;
```

**frontend/src/pages/HistoryPage.jsx**:
```jsx
function HistoryPage() {
  return (
    <div>
      <h2>Historial de Entrenamientos</h2>
      <p>Funcionalidad en desarrollo - Etapa 6</p>
    </div>
  );
}

export default HistoryPage;
```

### 4.7 ESTILOS GLOBALES

**frontend/src/index.css**:
```css
* {
  box-sizing: border-box;
}

body {
  margin: 0;
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', 'Roboto', 'Oxygen',
    'Ubuntu', 'Cantarell', 'Fira Sans', 'Droid Sans', 'Helvetica Neue',
    sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  background-color: #f5f7fa;
}

code {
  font-family: source-code-pro, Menlo, Monaco, Consolas, 'Courier New',
    monospace;
}

h1, h2, h3, h4, h5, h6 {
  margin-top: 0;
}

button {
  font-family: inherit;
}
```

### 4.8 EJECUTAR FRONTEND Y BACKEND JUNTOS

**Terminal 1 (Backend)**:
```bash
cd backend
dotnet run
```

**Terminal 2 (Frontend)**:
```bash
cd frontend
npm run dev
```

**Abrir navegador**: http://localhost:5173

---

## ✅ CHECKPOINT ETAPA 4

- ✅ React Router configurado
- ✅ Layout y navegación funcionando
- ✅ Axios configurado con servicios
- ✅ Página de ejercicios mostrando datos del backend
- ✅ Filtros funcionando
- ✅ Eliminación de ejercicios funcionando

---

## 🔗 ETAPA 5: INTEGRACIÓN FRONTEND-BACKEND Y FUNCIONALIDADES COMPLETAS

### Objetivo
Completar el CRUD de ejercicios con formularios para crear y editar.

### 5.1 CREAR COMPONENTE DE FORMULARIO

**frontend/src/components/exercises/ExerciseForm.jsx**:
```jsx
import { useState, useEffect } from 'react';
import { exerciseService } from '../../services/api';
import './ExerciseForm.css';

function ExerciseForm({ exerciseId, onClose, onSuccess }) {
  const [formData, setFormData] = useState({
    name: '',
    description: '',
    category: '',
    durationMinutes: 0,
    difficultyLevel: '',
    additionalNotes: '',
  });
  const [categories, setCategories] = useState([]);
  const [difficulties, setDifficulties] = useState([]);
  const [loading, setLoading] = useState(false);
  const [errors, setErrors] = useState({});

  useEffect(() => {
    loadDropdownData();
    if (exerciseId) {
      loadExercise();
    }
  }, [exerciseId]);

  const loadDropdownData = async () => {
    try {
      const [catResponse, diffResponse] = await Promise.all([
        exerciseService.getCategories(),
        exerciseService.getDifficulties(),
      ]);
      setCategories(catResponse.data);
      setDifficulties(diffResponse.data);
    } catch (err) {
      console.error('Error loading dropdown data:', err);
    }
  };

  const loadExercise = async () => {
    try {
      setLoading(true);
      const response = await exerciseService.getById(exerciseId);
      setFormData(response.data);
    } catch (err) {
      alert('Error al cargar ejercicio');
    } finally {
      setLoading(false);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: name === 'durationMinutes' ? parseInt(value) || 0 : value,
    }));
    // Limpiar error del campo
    if (errors[name]) {
      setErrors((prev) => ({ ...prev, [name]: null }));
    }
  };

  const validate = () => {
    const newErrors = {};
    if (!formData.name.trim()) newErrors.name = 'El nombre es requerido';
    if (!formData.description.trim()) newErrors.description = 'La descripción es requerida';
    if (!formData.category) newErrors.category = 'La categoría es requerida';
    if (!formData.difficultyLevel) newErrors.difficultyLevel = 'La dificultad es requerida';
    if (formData.durationMinutes <= 0) newErrors.durationMinutes = 'La duración debe ser mayor a 0';

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!validate()) return;

    try {
      setLoading(true);
      if (exerciseId) {
        await exerciseService.update(exerciseId, formData);
      } else {
        await exerciseService.create(formData);
      }
      onSuccess();
      onClose();
    } catch (err) {
      alert('Error al guardar ejercicio');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <div className="modal-header">
          <h2>{exerciseId ? 'Editar Ejercicio' : 'Nuevo Ejercicio'}</h2>
          <button className="close-btn" onClick={onClose}>
            ✕
          </button>
        </div>

        <form onSubmit={handleSubmit} className="exercise-form">
          <div className="form-group">
            <label htmlFor="name">Nombre *</label>
            <input
              type="text"
              id="name"
              name="name"
              value={formData.name}
              onChange={handleChange}
              className={errors.name ? 'error' : ''}
            />
            {errors.name && <span className="error-message">{errors.name}</span>}
          </div>

          <div className="form-group">
            <label htmlFor="description">Descripción *</label>
            <textarea
              id="description"
              name="description"
              value={formData.description}
              onChange={handleChange}
              rows="4"
              className={errors.description ? 'error' : ''}
            />
            {errors.description && <span className="error-message">{errors.description}</span>}
          </div>

          <div className="form-row">
            <div className="form-group">
              <label htmlFor="category">Categoría *</label>
              <select
                id="category"
                name="category"
                value={formData.category}
                onChange={handleChange}
                className={errors.category ? 'error' : ''}
              >
                <option value="">Selecciona una categoría</option>
                {categories.map((cat) => (
                  <option key={cat} value={cat}>
                    {cat}
                  </option>
                ))}
              </select>
              {errors.category && <span className="error-message">{errors.category}</span>}
            </div>

            <div className="form-group">
              <label htmlFor="difficultyLevel">Dificultad *</label>
              <select
                id="difficultyLevel"
                name="difficultyLevel"
                value={formData.difficultyLevel}
                onChange={handleChange}
                className={errors.difficultyLevel ? 'error' : ''}
              >
                <option value="">Selecciona dificultad</option>
                {difficulties.map((diff) => (
                  <option key={diff} value={diff}>
                    {diff}
                  </option>
                ))}
              </select>
              {errors.difficultyLevel && (
                <span className="error-message">{errors.difficultyLevel}</span>
              )}
            </div>
          </div>

          <div className="form-group">
            <label htmlFor="durationMinutes">Duración (minutos) *</label>
            <input
              type="number"
              id="durationMinutes"
              name="durationMinutes"
              value={formData.durationMinutes}
              onChange={handleChange}
              min="1"
              className={errors.durationMinutes ? 'error' : ''}
            />
            {errors.durationMinutes && (
              <span className="error-message">{errors.durationMinutes}</span>
            )}
          </div>

          <div className="form-group">
            <label htmlFor="additionalNotes">Notas adicionales</label>
            <textarea
              id="additionalNotes"
              name="additionalNotes"
              value={formData.additionalNotes || ''}
              onChange={handleChange}
              rows="3"
            />
          </div>

          <div className="form-actions">
            <button type="button" className="btn btn-secondary" onClick={onClose}>
              Cancelar
            </button>
            <button type="submit" className="btn btn-primary" disabled={loading}>
              {loading ? 'Guardando...' : 'Guardar'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default ExerciseForm;
```

**frontend/src/components/exercises/ExerciseForm.css**:
```css
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.modal-content {
  background: white;
  border-radius: 8px;
  width: 90%;
  max-width: 600px;
  max-height: 90vh;
  overflow-y: auto;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
}

.modal-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1.5rem;
  border-bottom: 1px solid #eee;
}

.modal-header h2 {
  margin: 0;
}

.close-btn {
  background: none;
  border: none;
  font-size: 1.5rem;
  cursor: pointer;
  color: #666;
  padding: 0;
  width: 30px;
  height: 30px;
}

.close-btn:hover {
  color: #000;
}

.exercise-form {
  padding: 1.5rem;
}

.form-group {
  margin-bottom: 1.5rem;
}

.form-group label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: 500;
  color: #333;
}

.form-group input,
.form-group select,
.form-group textarea {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 1rem;
  font-family: inherit;
}

.form-group input:focus,
.form-group select:focus,
.form-group textarea:focus {
  outline: none;
  border-color: #667eea;
}

.form-group input.error,
.form-group select.error,
.form-group textarea.error {
  border-color: #dc3545;
}

.error-message {
  color: #dc3545;
  font-size: 0.85rem;
  margin-top: 0.25rem;
  display: block;
}

.form-row {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 1rem;
}

.form-actions {
  display: flex;
  justify-content: flex-end;
  gap: 1rem;
  margin-top: 2rem;
  padding-top: 1rem;
  border-top: 1px solid #eee;
}
```

### 5.2 ACTUALIZAR ExercisesPage CON FORMULARIO

**Modificar `frontend/src/pages/ExercisesPage.jsx`** (agregar estado y funciones):

```jsx
import { useState, useEffect } from 'react';
import { exerciseService } from '../services/api';
import ExerciseForm from '../components/exercises/ExerciseForm';
import './ExercisesPage.css';

function ExercisesPage() {
  const [exercises, setExercises] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [selectedCategory, setSelectedCategory] = useState('');
  const [selectedDifficulty, setSelectedDifficulty] = useState('');
  const [categories, setCategories] = useState([]);
  const [difficulties, setDifficulties] = useState([]);

  // NUEVO: Estado para el formulario
  const [showForm, setShowForm] = useState(false);
  const [editingId, setEditingId] = useState(null);

  // ... (mantener funciones existentes: loadCategories, loadDifficulties, loadExercises)

  // NUEVO: Funciones para manejar el formulario
  const handleCreate = () => {
    setEditingId(null);
    setShowForm(true);
  };

  const handleEdit = (id) => {
    setEditingId(id);
    setShowForm(true);
  };

  const handleCloseForm = () => {
    setShowForm(false);
    setEditingId(null);
  };

  const handleFormSuccess = () => {
    loadExercises();
  };

  // ... (mantener return con modificaciones en botones)

  return (
    <div className="exercises-page">
      <div className="page-header">
        <h2>Ejercicios de Entrenamiento</h2>
        <button className="btn btn-primary" onClick={handleCreate}>
          + Nuevo Ejercicio
        </button>
      </div>

      {/* ... filtros ... */}

      <div className="exercises-grid">
        {exercises.length === 0 ? (
          <p className="no-data">No hay ejercicios disponibles</p>
        ) : (
          exercises.map((exercise) => (
            <div key={exercise.id} className="exercise-card">
              {/* ... contenido de la tarjeta ... */}
              <div className="exercise-actions">
                <button
                  className="btn btn-secondary"
                  onClick={() => handleEdit(exercise.id)}
                >
                  Editar
                </button>
                <button
                  className="btn btn-danger"
                  onClick={() => handleDelete(exercise.id)}
                >
                  Eliminar
                </button>
              </div>
            </div>
          ))
        )}
      </div>

      {/* NUEVO: Renderizar formulario modal */}
      {showForm && (
        <ExerciseForm
          exerciseId={editingId}
          onClose={handleCloseForm}
          onSuccess={handleFormSuccess}
        />
      )}
    </div>
  );
}

export default ExercisesPage;
```

### 5.3 AGREGAR DATOS DE EJEMPLO

**Crear algunos ejercicios usando la UI**:

1. Ejecutar backend y frontend
2. Click en "+ Nuevo Ejercicio"
3. Llenar formulario con ejercicios reales

**Ejemplos de ejercicios**:

```
Nombre: Saque con efecto lateral
Categoría: Entrenamiento Inicial
Dificultad: Intermedio
Duración: 15 min
Descripción: Practicar saques con efecto lateral (sidespin) alternando entre derecha e izquierda.
Notas: Enfocarse en el contacto de la raqueta con la pelota.

---

Nombre: Movimiento de piernas en estrella
Categoría: Ejercicios de Movilidad Avanzada
Dificultad: Avanzado
Duración: 20 min
Descripción: Ejercicio de desplazamiento en forma de estrella desde el centro de la mesa.

---

Nombre: Trote ligero y estiramientos
Categoría: Calentamiento
Dificultad: Principiante
Duración: 10 min
Descripción: Trote ligero alrededor de la mesa seguido de estiramientos de brazos y piernas.
```

### 5.4 MEJORAR MANEJO DE ERRORES

**Crear componente de Toast/Notificación** (opcional pero recomendado):

**frontend/src/components/common/Toast.jsx**:
```jsx
import { useEffect } from 'react';
import './Toast.css';

function Toast({ message, type = 'success', onClose }) {
  useEffect(() => {
    const timer = setTimeout(() => {
      onClose();
    }, 3000);

    return () => clearTimeout(timer);
  }, [onClose]);

  return (
    <div className={`toast toast-${type}`}>
      {type === 'success' && '✓ '}
      {type === 'error' && '✕ '}
      {message}
    </div>
  );
}

export default Toast;
```

**frontend/src/components/common/Toast.css**:
```css
.toast {
  position: fixed;
  top: 20px;
  right: 20px;
  padding: 1rem 1.5rem;
  border-radius: 4px;
  color: white;
  font-weight: 500;
  z-index: 2000;
  animation: slideIn 0.3s ease-out;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
}

@keyframes slideIn {
  from {
    transform: translateX(100%);
    opacity: 0;
  }
  to {
    transform: translateX(0);
    opacity: 1;
  }
}

.toast-success {
  background-color: #28a745;
}

.toast-error {
  background-color: #dc3545;
}

.toast-info {
  background-color: #17a2b8;
}
```

---

## ✅ CHECKPOINT ETAPA 5

- ✅ CRUD completo de ejercicios funcionando
- ✅ Formulario modal para crear y editar
- ✅ Validación de formularios
- ✅ Filtros por categoría y dificultad
- ✅ Integración completa frontend-backend

---

## 🚀 ETAPA 6: FUNCIONALIDADES AVANZADAS (RUTINAS Y HISTORIAL)

### Objetivo
Implementar gestión de rutinas personalizadas y historial de entrenamientos.

### 6.1 BACKEND - CONTROLLERS DE RUTINAS

**Controllers/RoutinesController.cs**:
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableTennisApi.Data;
using TableTennisApi.Models;

namespace TableTennisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutinesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoutinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Routines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetRoutines()
        {
            var routines = await _context.Routines
                .Include(r => r.RoutineExercises)
                    .ThenInclude(re => re.Exercise)
                .Select(r => new
                {
                    r.Id,
                    r.Name,
                    r.Description,
                    r.TotalDuration,
                    r.CreatedAt,
                    ExerciseCount = r.RoutineExercises.Count
                })
                .ToListAsync();

            return Ok(routines);
        }

        // GET: api/Routines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetRoutine(int id)
        {
            var routine = await _context.Routines
                .Include(r => r.RoutineExercises)
                    .ThenInclude(re => re.Exercise)
                .Where(r => r.Id == id)
                .Select(r => new
                {
                    r.Id,
                    r.Name,
                    r.Description,
                    r.TotalDuration,
                    Exercises = r.RoutineExercises
                        .OrderBy(re => re.OrderIndex)
                        .Select(re => new
                        {
                            re.Id,
                            re.ExerciseId,
                            re.OrderIndex,
                            re.CustomDuration,
                            re.Notes,
                            Exercise = new
                            {
                                re.Exercise.Id,
                                re.Exercise.Name,
                                re.Exercise.Description,
                                re.Exercise.Category,
                                re.Exercise.DurationMinutes,
                                re.Exercise.DifficultyLevel
                            }
                        })
                })
                .FirstOrDefaultAsync();

            if (routine == null)
            {
                return NotFound();
            }

            return Ok(routine);
        }

        // POST: api/Routines
        [HttpPost]
        public async Task<ActionResult> CreateRoutine(CreateRoutineDto dto)
        {
            var routine = new Routine
            {
                Name = dto.Name,
                Description = dto.Description,
                TotalDuration = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Routines.Add(routine);
            await _context.SaveChangesAsync();

            if (dto.ExerciseIds != null && dto.ExerciseIds.Any())
            {
                int orderIndex = 0;
                foreach (var exerciseId in dto.ExerciseIds)
                {
                    var exercise = await _context.Exercises.FindAsync(exerciseId);
                    if (exercise != null)
                    {
                        var routineExercise = new RoutineExercise
                        {
                            RoutineId = routine.Id,
                            ExerciseId = exerciseId,
                            OrderIndex = orderIndex++,
                            CustomDuration = null
                        };
                        _context.RoutineExercises.Add(routineExercise);
                        routine.TotalDuration += exercise.DurationMinutes;
                    }
                }
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(GetRoutine), new { id = routine.Id }, routine);
        }

        // PUT: api/Routines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoutine(int id, UpdateRoutineDto dto)
        {
            var routine = await _context.Routines
                .Include(r => r.RoutineExercises)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (routine == null)
            {
                return NotFound();
            }

            routine.Name = dto.Name;
            routine.Description = dto.Description;
            routine.UpdatedAt = DateTime.UtcNow;

            // Eliminar ejercicios existentes
            _context.RoutineExercises.RemoveRange(routine.RoutineExercises);

            // Agregar nuevos ejercicios
            routine.TotalDuration = 0;
            if (dto.ExerciseIds != null && dto.ExerciseIds.Any())
            {
                int orderIndex = 0;
                foreach (var exerciseId in dto.ExerciseIds)
                {
                    var exercise = await _context.Exercises.FindAsync(exerciseId);
                    if (exercise != null)
                    {
                        var routineExercise = new RoutineExercise
                        {
                            RoutineId = routine.Id,
                            ExerciseId = exerciseId,
                            OrderIndex = orderIndex++
                        };
                        _context.RoutineExercises.Add(routineExercise);
                        routine.TotalDuration += exercise.DurationMinutes;
                    }
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Routines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoutine(int id)
        {
            var routine = await _context.Routines.FindAsync(id);
            if (routine == null)
            {
                return NotFound();
            }

            _context.Routines.Remove(routine);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class CreateRoutineDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<int>? ExerciseIds { get; set; }
    }

    public class UpdateRoutineDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<int>? ExerciseIds { get; set; }
    }
}
```

### 6.2 BACKEND - CONTROLLER DE HISTORIAL

**Controllers/TrainingHistoryController.cs**:
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableTennisApi.Data;
using TableTennisApi.Models;

namespace TableTennisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingHistoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrainingHistoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainingHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetHistory()
        {
            var history = await _context.TrainingHistories
                .Include(th => th.Routine)
                .OrderByDescending(th => th.TrainingDate)
                .Select(th => new
                {
                    th.Id,
                    th.RoutineId,
                    RoutineName = th.Routine.Name,
                    th.TrainingDate,
                    th.CompletedDuration,
                    th.Rating,
                    th.Notes
                })
                .ToListAsync();

            return Ok(history);
        }

        // POST: api/TrainingHistory
        [HttpPost]
        public async Task<ActionResult> CreateHistory(CreateHistoryDto dto)
        {
            var history = new TrainingHistory
            {
                RoutineId = dto.RoutineId,
                TrainingDate = dto.TrainingDate,
                CompletedDuration = dto.CompletedDuration,
                Rating = dto.Rating,
                Notes = dto.Notes
            };

            _context.TrainingHistories.Add(history);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHistory), new { id = history.Id }, history);
        }

        // DELETE: api/TrainingHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistory(int id)
        {
            var history = await _context.TrainingHistories.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }

            _context.TrainingHistories.Remove(history);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class CreateHistoryDto
    {
        public int RoutineId { get; set; }
        public DateTime TrainingDate { get; set; }
        public int CompletedDuration { get; set; }
        public int Rating { get; set; }
        public string? Notes { get; set; }
    }
}
```

### 6.3 FRONTEND - SERVICIOS API

**Actualizar `frontend/src/services/api.js`**:
```javascript
// ... (mantener código existente y agregar)

// Rutinas
export const routineService = {
  getAll: () => api.get('/api/routines'),
  getById: (id) => api.get(`/api/routines/${id}`),
  create: (data) => api.post('/api/routines', data),
  update: (id, data) => api.put(`/api/routines/${id}`, data),
  delete: (id) => api.delete(`/api/routines/${id}`),
};

// Historial
export const historyService = {
  getAll: () => api.get('/api/traininghistory'),
  create: (data) => api.post('/api/traininghistory', data),
  delete: (id) => api.delete(`/api/traininghistory/${id}`),
};
```

### 6.4 FRONTEND - PÁGINA DE RUTINAS

**Completar `frontend/src/pages/RoutinesPage.jsx`**:
```jsx
import { useState, useEffect } from 'react';
import { routineService } from '../services/api';
import RoutineForm from '../components/routines/RoutineForm';
import './RoutinesPage.css';

function RoutinesPage() {
  const [routines, setRoutines] = useState([]);
  const [loading, setLoading] = useState(true);
  const [showForm, setShowForm] = useState(false);
  const [editingId, setEditingId] = useState(null);

  useEffect(() => {
    loadRoutines();
  }, []);

  const loadRoutines = async () => {
    try {
      setLoading(true);
      const response = await routineService.getAll();
      setRoutines(response.data);
    } catch (err) {
      console.error('Error loading routines:', err);
    } finally {
      setLoading(false);
    }
  };

  const handleCreate = () => {
    setEditingId(null);
    setShowForm(true);
  };

  const handleEdit = (id) => {
    setEditingId(id);
    setShowForm(true);
  };

  const handleDelete = async (id) => {
    if (window.confirm('¿Eliminar esta rutina?')) {
      try {
        await routineService.delete(id);
        loadRoutines();
      } catch (err) {
        alert('Error al eliminar rutina');
      }
    }
  };

  if (loading) return <div className="loading">Cargando rutinas...</div>;

  return (
    <div className="routines-page">
      <div className="page-header">
        <h2>Rutinas de Entrenamiento</h2>
        <button className="btn btn-primary" onClick={handleCreate}>
          + Nueva Rutina
        </button>
      </div>

      <div className="routines-grid">
        {routines.length === 0 ? (
          <p className="no-data">No hay rutinas creadas</p>
        ) : (
          routines.map((routine) => (
            <div key={routine.id} className="routine-card">
              <h3>{routine.name}</h3>
              <p>{routine.description}</p>
              <div className="routine-meta">
                <span>{routine.exerciseCount} ejercicios</span>
                <span>{routine.totalDuration} min</span>
              </div>
              <div className="routine-actions">
                <button className="btn btn-secondary" onClick={() => handleEdit(routine.id)}>
                  Editar
                </button>
                <button className="btn btn-danger" onClick={() => handleDelete(routine.id)}>
                  Eliminar
                </button>
              </div>
            </div>
          ))
        )}
      </div>

      {showForm && (
        <RoutineForm
          routineId={editingId}
          onClose={() => setShowForm(false)}
          onSuccess={() => {
            loadRoutines();
            setShowForm(false);
          }}
        />
      )}
    </div>
  );
}

export default RoutinesPage;
```

**frontend/src/components/routines/RoutineForm.jsx** (simplificado):
```jsx
import { useState, useEffect } from 'react';
import { routineService, exerciseService } from '../../services/api';
import '../exercises/ExerciseForm.css';

function RoutineForm({ routineId, onClose, onSuccess }) {
  const [formData, setFormData] = useState({
    name: '',
    description: '',
    exerciseIds: [],
  });
  const [exercises, setExercises] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    loadExercises();
    if (routineId) loadRoutine();
  }, [routineId]);

  const loadExercises = async () => {
    try {
      const response = await exerciseService.getAll();
      setExercises(response.data);
    } catch (err) {
      console.error(err);
    }
  };

  const loadRoutine = async () => {
    try {
      const response = await routineService.getById(routineId);
      setFormData({
        name: response.data.name,
        description: response.data.description,
        exerciseIds: response.data.exercises.map((e) => e.exerciseId),
      });
    } catch (err) {
      console.error(err);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      setLoading(true);
      if (routineId) {
        await routineService.update(routineId, formData);
      } else {
        await routineService.create(formData);
      }
      onSuccess();
    } catch (err) {
      alert('Error al guardar rutina');
    } finally {
      setLoading(false);
    }
  };

  const toggleExercise = (id) => {
    setFormData((prev) => ({
      ...prev,
      exerciseIds: prev.exerciseIds.includes(id)
        ? prev.exerciseIds.filter((eid) => eid !== id)
        : [...prev.exerciseIds, id],
    }));
  };

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <div className="modal-header">
          <h2>{routineId ? 'Editar Rutina' : 'Nueva Rutina'}</h2>
          <button className="close-btn" onClick={onClose}>✕</button>
        </div>

        <form onSubmit={handleSubmit} className="exercise-form">
          <div className="form-group">
            <label>Nombre</label>
            <input
              type="text"
              value={formData.name}
              onChange={(e) => setFormData({ ...formData, name: e.target.value })}
              required
            />
          </div>

          <div className="form-group">
            <label>Descripción</label>
            <textarea
              value={formData.description}
              onChange={(e) => setFormData({ ...formData, description: e.target.value })}
              rows="3"
            />
          </div>

          <div className="form-group">
            <label>Selecciona Ejercicios</label>
            <div className="exercise-checklist">
              {exercises.map((exercise) => (
                <label key={exercise.id} className="checkbox-label">
                  <input
                    type="checkbox"
                    checked={formData.exerciseIds.includes(exercise.id)}
                    onChange={() => toggleExercise(exercise.id)}
                  />
                  {exercise.name} ({exercise.durationMinutes} min)
                </label>
              ))}
            </div>
          </div>

          <div className="form-actions">
            <button type="button" className="btn btn-secondary" onClick={onClose}>
              Cancelar
            </button>
            <button type="submit" className="btn btn-primary" disabled={loading}>
              Guardar
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default RoutineForm;
```

**Agregar estilos en ExerciseForm.css**:
```css
.exercise-checklist {
  max-height: 300px;
  overflow-y: auto;
  border: 1px solid #ddd;
  border-radius: 4px;
  padding: 1rem;
}

.checkbox-label {
  display: block;
  padding: 0.5rem;
  cursor: pointer;
}

.checkbox-label input {
  margin-right: 0.5rem;
  width: auto;
}

.checkbox-label:hover {
  background-color: #f5f5f5;
}
```

### 6.5 FRONTEND - PÁGINA DE HISTORIAL

**Completar `frontend/src/pages/HistoryPage.jsx`**:
```jsx
import { useState, useEffect } from 'react';
import { historyService } from '../services/api';
import './HistoryPage.css';

function HistoryPage() {
  const [history, setHistory] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadHistory();
  }, []);

  const loadHistory = async () => {
    try {
      setLoading(true);
      const response = await historyService.getAll();
      setHistory(response.data);
    } catch (err) {
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm('¿Eliminar este registro?')) {
      try {
        await historyService.delete(id);
        loadHistory();
      } catch (err) {
        alert('Error al eliminar');
      }
    }
  };

  if (loading) return <div className="loading">Cargando historial...</div>;

  return (
    <div className="history-page">
      <h2>Historial de Entrenamientos</h2>

      {history.length === 0 ? (
        <p className="no-data">No hay entrenamientos registrados</p>
      ) : (
        <table className="history-table">
          <thead>
            <tr>
              <th>Fecha</th>
              <th>Rutina</th>
              <th>Duración</th>
              <th>Calificación</th>
              <th>Notas</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
            {history.map((item) => (
              <tr key={item.id}>
                <td>{new Date(item.trainingDate).toLocaleDateString()}</td>
                <td>{item.routineName}</td>
                <td>{item.completedDuration} min</td>
                <td>{'⭐'.repeat(item.rating)}</td>
                <td>{item.notes || '-'}</td>
                <td>
                  <button className="btn btn-danger btn-sm" onClick={() => handleDelete(item.id)}>
                    Eliminar
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default HistoryPage;
```

**frontend/src/pages/HistoryPage.css**:
```css
.history-page {
  animation: fadeIn 0.3s;
}

.history-table {
  width: 100%;
  background: white;
  border-radius: 8px;
  overflow: hidden;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
  margin-top: 2rem;
}

.history-table th,
.history-table td {
  padding: 1rem;
  text-align: left;
  border-bottom: 1px solid #eee;
}

.history-table th {
  background-color: #667eea;
  color: white;
  font-weight: 600;
}

.history-table tr:last-child td {
  border-bottom: none;
}

.history-table tr:hover {
  background-color: #f8f9fa;
}

.btn-sm {
  padding: 0.25rem 0.75rem;
  font-size: 0.85rem;
}
```

---

## ✅ CHECKPOINT ETAPA 6

- ✅ CRUD de rutinas funcionando
- ✅ Selección de múltiples ejercicios
- ✅ Historial de entrenamientos
- ✅ Todas las funcionalidades principales completas

---

## ☁️ ETAPA 7: PREPARACIÓN PARA CLOUD Y DEPLOYMENT

### Objetivo
Configurar Docker, optimizar para producción y preparar deployment en Google Cloud Platform.

### 7.1 DOCKERIZAR BACKEND

**backend/Dockerfile**:
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TableTennisApi.csproj", "./"]
RUN dotnet restore "TableTennisApi.csproj"
COPY . .
RUN dotnet build "TableTennisApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TableTennisApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TableTennisApi.dll"]
```

**backend/.dockerignore**:
```
bin/
obj/
*.user
.vs/
```

### 7.2 DOCKERIZAR FRONTEND

**frontend/Dockerfile**:
```dockerfile
# Build stage
FROM node:20-alpine AS build
WORKDIR /app
COPY package*.json ./
RUN npm ci
COPY . .
RUN npm run build

# Production stage
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
```

**frontend/nginx.conf**:
```nginx
server {
    listen 80;
    server_name localhost;
    root /usr/share/nginx/html;
    index index.html;

    location / {
        try_files $uri $uri/ /index.html;
    }

    location /api {
        proxy_pass http://backend:80;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection 'upgrade';
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}
```

**frontend/.dockerignore**:
```
node_modules/
dist/
build/
.env
```

### 7.3 DOCKER COMPOSE

**Raíz del proyecto: docker-compose.yml**:
```yaml
version: '3.8'

services:
  database:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=YourStrongP@ssw0rd!
      - MSSQL_PID=Developer
    ports:
      - "1433:1433"
    volumes:
      - sqldata:/var/opt/mssql

  backend:
    build:
      context: ./backend
      dockerfile: Dockerfile
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ConnectionStrings__DefaultConnection=Server=database;Database=TableTennisTrainingDB;User Id=sa;Password=YourStrongP@ssw0rd!;TrustServerCertificate=True;
    ports:
      - "5000:80"
    depends_on:
      - database

  frontend:
    build:
      context: ./frontend
      dockerfile: Dockerfile
    ports:
      - "3000:80"
    depends_on:
      - backend

volumes:
  sqldata:
```

### 7.4 CONFIGURACIÓN PARA GOOGLE CLOUD

**Crear `cloudbuild.yaml` (para Cloud Build)**:
```yaml
steps:
  # Build backend
  - name: 'gcr.io/cloud-builders/docker'
    args: ['build', '-t', 'gcr.io/$PROJECT_ID/tabletennis-backend', './backend']

  # Build frontend
  - name: 'gcr.io/cloud-builders/docker'
    args: ['build', '-t', 'gcr.io/$PROJECT_ID/tabletennis-frontend', './frontend']

  # Push images
  - name: 'gcr.io/cloud-builders/docker'
    args: ['push', 'gcr.io/$PROJECT_ID/tabletennis-backend']

  - name: 'gcr.io/cloud-builders/docker'
    args: ['push', 'gcr.io/$PROJECT_ID/tabletennis-frontend']

images:
  - 'gcr.io/$PROJECT_ID/tabletennis-backend'
  - 'gcr.io/$PROJECT_ID/tabletennis-frontend'
```

### 7.5 OPTIMIZACIONES DE PRODUCCIÓN

**Backend - appsettings.Production.json**:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Connection string desde variables de entorno"
  }
}
```

**Frontend - Optimización del Build**:
```bash
# Ya configurado en Vite
npm run build
```

### 7.6 VARIABLES DE ENTORNO PARA CLOUD

**Backend** - Usar Google Secret Manager:
```bash
# Ejemplo de comando gcloud
gcloud secrets create connection-string --data-file=connection-string.txt
```

**Frontend** - Variables en tiempo de build:
```bash
VITE_API_URL=https://api.tu-dominio.com npm run build
```

### 7.7 GUÍA DE DEPLOYMENT EN GCP

**docs/deployment-guide.md**:
```markdown
# Guía de Deployment en Google Cloud Platform

## Prerrequisitos
1. Cuenta de Google Cloud con facturación activada
2. Google Cloud SDK instalado
3. Docker instalado localmente

## Pasos de Deployment

### 1. Configurar GCP Project
```bash
gcloud config set project YOUR_PROJECT_ID
gcloud auth configure-docker
```

### 2. Crear Base de Datos (Cloud SQL)
```bash
gcloud sql instances create tabletennis-db \
  --database-version=SQLSERVER_2019_STANDARD \
  --tier=db-custom-2-7680 \
  --region=us-central1
```

### 3. Build y Push de Imágenes
```bash
docker build -t gcr.io/YOUR_PROJECT_ID/backend ./backend
docker push gcr.io/YOUR_PROJECT_ID/backend

docker build -t gcr.io/YOUR_PROJECT_ID/frontend ./frontend
docker push gcr.io/YOUR_PROJECT_ID/frontend
```

### 4. Deploy en Cloud Run
```bash
# Backend
gcloud run deploy tabletennis-backend \
  --image gcr.io/YOUR_PROJECT_ID/backend \
  --platform managed \
  --region us-central1 \
  --allow-unauthenticated

# Frontend
gcloud run deploy tabletennis-frontend \
  --image gcr.io/YOUR_PROJECT_ID/frontend \
  --platform managed \
  --region us-central1 \
  --allow-unauthenticated
```

### 5. Configurar Dominio (Opcional)
```bash
gcloud run domain-mappings create \
  --service tabletennis-frontend \
  --domain www.tu-dominio.com
```

## Costos Estimados
- Cloud Run (backend): ~$5-10/mes con tráfico bajo
- Cloud Run (frontend): ~$2-5/mes
- Cloud SQL: ~$25-50/mes
- **Total estimado**: $32-65/mes

## Alternativas Económicas
- **Base de datos**: Usar PostgreSQL en lugar de SQL Server (más barato)
- **Hosting frontend**: Firebase Hosting (gratis hasta cierto límite)
- **Backend**: Cloud Functions para APIs simples
```

### 7.8 HEALTH CHECKS Y MONITORING

**Agregar endpoint de health check en backend**:

**Program.cs** (agregar antes de `app.Run()`):
```csharp
app.MapGet("/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }));
```

### 7.9 CI/CD CON GITHUB ACTIONS (BONUS)

**.github/workflows/deploy.yml**:
```yaml
name: Deploy to GCP

on:
  push:
    branches: [ main ]

jobs:
  deploy:
    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v3

    - name: Setup Cloud SDK
      uses: google-github-actions/setup-gcloud@v1
      with:
        project_id: ${{ secrets.GCP_PROJECT_ID }}
        service_account_key: ${{ secrets.GCP_SA_KEY }}

    - name: Build and Push Backend
      run: |
        docker build -t gcr.io/${{ secrets.GCP_PROJECT_ID }}/backend ./backend
        docker push gcr.io/${{ secrets.GCP_PROJECT_ID }}/backend

    - name: Deploy to Cloud Run
      run: |
        gcloud run deploy tabletennis-backend \
          --image gcr.io/${{ secrets.GCP_PROJECT_ID }}/backend \
          --platform managed \
          --region us-central1
```

---

## ✅ CHECKPOINT ETAPA 7

- ✅ Dockerfiles creados para backend y frontend
- ✅ Docker Compose configurado para desarrollo local
- ✅ Configuración para Google Cloud Platform
- ✅ Guía de deployment documentada
- ✅ Health checks implementados
- ✅ CI/CD configurado (opcional)

---

## 🎓 RESUMEN Y PRÓXIMOS PASOS

### ¿Qué has aprendido?

**Frontend (React)**:
- ✅ Configuración de Vite
- ✅ Componentes funcionales y hooks
- ✅ React Router para navegación
- ✅ Axios para peticiones HTTP
- ✅ Manejo de estado con useState/useEffect
- ✅ Formularios controlados

**Backend (C# .NET)**:
- ✅ Web API con .NET 8
- ✅ Entity Framework Core
- ✅ Code-First Migrations
- ✅ DTOs y separación de responsabilidades
- ✅ CORS para integración con frontend
- ✅ Relaciones de base de datos (1:N, N:M)

**Base de Datos (SQL Server)**:
- ✅ Diseño de modelo relacional
- ✅ Migraciones con EF Core
- ✅ Queries con LINQ

**DevOps/Cloud**:
- ✅ Docker y Docker Compose
- ✅ Preparación para Google Cloud Platform
- ✅ Variables de entorno
- ✅ CI/CD básico

### Funcionalidades Implementadas

- ✅ CRUD completo de ejercicios
- ✅ Filtrado por categoría y dificultad
- ✅ Creación de rutinas personalizadas
- ✅ Historial de entrenamientos
- ✅ Interfaz responsive y moderna

### Mejoras Futuras (Opcionales)

1. **Autenticación y Autorización**
   - Login con JWT
   - Múltiples usuarios

2. **Funcionalidades Avanzadas**
   - Dashboard con estadísticas
   - Gráficos de progreso
   - Reordenar ejercicios en rutinas (drag & drop)
   - Temporizador durante entrenamientos

3. **Performance**
   - Paginación en listados
   - Caching con Redis
   - Lazy loading de imágenes

4. **Testing**
   - Unit tests (xUnit para backend)
   - Integration tests
   - E2E tests con Playwright

5. **Mobile**
   - PWA (Progressive Web App)
   - React Native app

### Comandos de Referencia Rápida

**Desarrollo Local**:
```bash
# Backend
cd backend
dotnet run

# Frontend
cd frontend
npm run dev

# Docker Compose
docker-compose up --build
```

**Base de Datos**:
```bash
# Nueva migración
dotnet ef migrations add NombreMigracion

# Aplicar migraciones
dotnet ef database update

# Revertir última migración
dotnet ef database update PreviousMigrationName
```

**Build para Producción**:
```bash
# Backend
dotnet publish -c Release

# Frontend
npm run build
```

---

## 🎉 ¡FELICITACIONES!

Has completado la implementación de una aplicación full-stack moderna y escalable. Ahora tienes:

- 📱 Una aplicación funcional de entrenamiento de tenis de mesa
- 🎓 Conocimientos sólidos de React, C#, y SQL Server
- ☁️ Preparación para deployment en la nube
- 🚀 Experiencia práctica con tecnologías demandadas en la industria

**Siguiente paso**: ¡Practicar, experimentar y agregar tus propias funcionalidades!
