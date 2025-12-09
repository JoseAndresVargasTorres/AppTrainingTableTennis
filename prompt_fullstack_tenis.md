# Prompt Guía Completa - Aplicación de Entrenamiento de Tenis de Mesa

Soy un desarrollador aprendiendo React + C# + SQL Server. Quiero crear una aplicación web para gestionar entrenamientos de tenis de mesa con arquitectura preparada para despliegue en la nube (Google Cloud, Azure, o AWS).

## 🎯 CONTEXTO DE LA APLICACIÓN

Necesito una app para administrar ejercicios de entrenamiento organizados en 5 categorías:

1. Calentamiento
2. Entrenamiento Inicial  
3. Ejercicios de Movilidad Avanzada
4. Ejercicios Inconsistentes
5. Ejercicios Enfocados en Situaciones de Partido

**Datos de cada ejercicio:**
- Nombre
- Descripción detallada
- Categoría
- Duración estimada (minutos)
- Nivel de dificultad (Principiante/Intermedio/Avanzado)
- Notas adicionales (opcional)

**Funcionalidades principales:**
- [ ] CRUD completo de ejercicios
- [ ] Filtrado por categoría y dificultad
- [ ] Creación de rutinas personalizadas
- [ ] Historial de entrenamientos
- [ ] [Otras funcionalidades futuras]

---

## 💻 MI SISTEMA OPERATIVO

- [ ] Windows 10/11


---

## 📊 MI NIVEL ACTUAL DE EXPERIENCIA

**Frontend (React):**

- [ ] Conozco HTML/CSS/JS pero no React

**Backend (C#/.NET):**

- [ ] He creado APIs REST básicas


**Base de Datos:**
- [ ] No sé SQL
- [ ] Conozco SQL básico (SELECT, INSERT, UPDATE, DELETE)


**DevOps/Cloud:**
- [ ] Nunca he desplegado en la nube


---

## 📦 PARTE 1: INSTALACIONES COMPLETAS

### FRONTEND (React + Herramientas)

Por favor proporcióname:

**1. Node.js**
- Versión LTS exacta recomendada
- Link de descarga oficial
- Comando para verificar instalación: `node --version` y `npm --version`
- ¿Debo agregar al PATH? (pasos exactos)

**2. Gestor de paquetes**
- ¿npm (incluido con Node) o yarn?
- Ventajas/desventajas de cada uno para este proyecto
- Comando de instalación si recomiendas yarn

**3. Herramienta de scaffolding**
- Create React App vs Vite vs Next.js
- ¿Cuál recomiendas para mi caso y por qué?
- Comando exacto para crear el proyecto

**4. Editor de código**
- Visual Studio Code (link de descarga)
- Extensiones ESENCIALES (con nombres exactos para buscar):
  * ESLint
  * Prettier
  * ES7+ React/Redux/React-Native snippets
  * [Otras que recomiendas]

**5. Librerías del proyecto**
- axios (para peticiones HTTP)
- react-router-dom (para navegación)
- [Otras librerías que recomiendas para formularios, UI, etc.]
- Comandos npm/yarn para instalarlas todas

**6. Herramientas de desarrollo**
- React Developer Tools (extensión de navegador)
- ¿Otras herramientas de debugging?

---

### BACKEND (C# + .NET + API)

Por favor proporcióname:

**1. .NET SDK**
- Versión LTS exacta recomendada (.NET 6, 7, 8?)
- Link de descarga oficial
- Comando para verificar instalación: `dotnet --version`
- ¿Necesito .NET Runtime por separado?

**2. IDE/Editor**
- Visual Studio 2022 Community vs Visual Studio Code
- ¿Cuál recomiendas para desarrollo de APIs y por qué?
- Si es VS Code: extensiones necesarias (C#, C# Dev Kit, etc.)
- Si es VS 2022: workloads que debo instalar

**3. Entity Framework Core**
- Versión compatible con mi .NET SDK
- Paquetes NuGet específicos:
  * Microsoft.EntityFrameworkCore
  * Microsoft.EntityFrameworkCore.SqlServer
  * Microsoft.EntityFrameworkCore.Tools
  * [Otros necesarios]
- Comandos para instalar vía CLI: `dotnet add package...`

**4. Paquetes para API REST**
- Swashbuckle.AspNetCore (Swagger/OpenAPI documentation)
- Microsoft.AspNetCore.Cors (para conectar con React)
- [Otros paquetes recomendados para seguridad, logging, etc.]

**5. Herramientas CLI útiles**
- .NET CLI comandos esenciales que debo conocer
- EF Core Tools para migraciones
- Comando de instalación: `dotnet tool install...`

**6. Testing (opcional pero recomendado)**
- xUnit vs NUnit vs MSTest - ¿cuál recomiendas?
- Paquetes necesarios para testing

---

### BASE DE DATOS (SQL Server)

Por favor proporcióname:

**1. SQL Server - Edición**
- Developer vs Express - ¿cuál para desarrollo local?
- Link de descarga oficial
- Versión recomendada (2019, 2022?)
- ¿Cuál es mejor para eventualmente migrar a la nube?

**2. SQL Server Management Studio (SSMS)**
- Link de descarga
- ¿Es obligatorio o puedo usar Azure Data Studio?
- Ventajas de cada uno

**3. Configuración inicial**
- ¿Authentication Mode: Windows o Mixed?
- ¿Qué opción es mejor para desarrollo y producción?
- Pasos para crear usuario/contraseña si uso Mixed Mode

**4. Herramientas adicionales**
- Azure Data Studio (¿ventajas sobre SSMS?)
- Extensiones útiles
- ¿Necesito SQL Server Configuration Manager?

**5. Connection String**
- Formato exacto para desarrollo local
- ¿Cómo lo configuro para que funcione con Entity Framework?
- Ejemplo de connection string seguro

---

## 📁 PARTE 2: ESTRUCTURA DE DIRECTORIOS

Por favor proporcióname una estructura de carpetas COMPLETA y DETALLADA que:

1. **Separe claramente Frontend y Backend**
   - ¿En repositorios separados o monorepo?
   - Ventajas/desventajas de cada enfoque

2. **Sea escalable**
   - Preparada para agregar más funcionalidades
   - Fácil de mantener con el equipo creciendo

3. **Siga mejores prácticas de la industria**
   - Clean Architecture
   - Separation of Concerns
   - Patrón Repository (si aplica)

4. **Esté lista para deployment en cloud**
   - Configuraciones separadas para dev/staging/production
   - Variables de entorno
   - Dockerfiles (si recomiendas Docker)

**Ejemplo de lo que necesito:**

```
proyecto-tenis-mesa/
│
├── frontend/                          # Aplicación React
│   ├── public/
│   ├── src/
│   │   ├── components/               # ¿Cómo organizo componentes?
│   │   ├── pages/                     # ¿O uso otra estructura?
│   │   ├── services/                  # Para llamadas API
│   │   ├── utils/
│   │   ├── App.js
│   │   └── index.js
│   ├── .env.development
│   ├── .env.production
│   ├── package.json
│   └── [otros archivos de config]
│
├── backend/                           # API en C# .NET
│   ├── Controllers/
│   ├── Models/
│   ├── Data/                          # ¿DbContext aquí?
│   ├── Services/                      # ¿Lógica de negocio?
│   ├── DTOs/                          # ¿Uso DTOs?
│   ├── [¿Qué más necesito?]
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   └── Program.cs
│
├── database/
│   ├── scripts/                       # Scripts SQL iniciales
│   └── migrations/                    # ¿O las manejo con EF?
│
├── docs/                              # Documentación
│
├── .gitignore                         # ¿Qué debo ignorar?
├── README.md
└── [archivos para Docker/Cloud si aplican]
```

**Por favor explícame:**
- ¿Esta estructura es correcta o debo modificarla?
- ¿Qué carpetas/archivos adicionales necesito?
- ¿Dónde van las configuraciones de cloud (Google Cloud, Azure)?
- ¿Debo incluir Docker desde el inicio o lo agrego después?

---

## ☁️ PARTE 3: PREPARACIÓN PARA CLOUD

**Proveedor cloud:**
- [ ] Google Cloud Platform (GCP)


**Por favor indícame:**

**1. Consideraciones de arquitectura desde el inicio**
- ¿Qué debo tener en cuenta AHORA para facilitar el deployment?
- ¿Configuraciones específicas en código?

**2. Variables de entorno**
- ¿Cómo las manejo en desarrollo vs producción?
- Herramientas recomendadas (.env files, Azure Key Vault, etc.)

**3. Base de datos en la nube**
- ¿SQL Server en VM vs Azure SQL Database vs Cloud SQL?
- ¿Qué cambios en mi connection string?

**4. Hosting del frontend**
- ¿Dónde debería hostear React? (Cloud Storage, App Service, etc.)
- ¿Necesito configurar un build optimizado?

**5. Hosting del backend API**
- ¿App Service, Cloud Run, contenedores?
- ¿Qué opción recomiendas para empezar?

**6. Docker**
- ¿Debo Dockerizar desde el inicio o después?
- Si digo que sí, ¿qué archivos Dockerfile necesito?

---

## 🚀 PARTE 4: ORDEN DE EJECUCIÓN

Una vez que tenga todo instalado, ¿en qué orden debo proceder?

Por favor dame una RUTA PASO A PASO:

**Fase 1: Configuración inicial**
- [ ] Instalar todas las herramientas
- [ ] Crear estructura de carpetas
- [ ] Inicializar repositorio Git
- [ ] ¿Qué más?

**Fase 2: Base de datos**
- [ ] Diseñar modelo de datos (tablas, relaciones)
- [ ] ¿Crear BD manualmente o con EF Migrations?
- [ ] ¿Qué más?

**Fase 3: Backend**
- [ ] Crear proyecto .NET Web API
- [ ] Configurar Entity Framework
- [ ] Implementar modelos
- [ ] ¿Qué más?

**Fase 4: Frontend**
- [ ] Crear proyecto React
- [ ] Configurar estructura de componentes
- [ ] ¿Qué más?

**Fase 5: Integración**
- [ ] Conectar Frontend con Backend
- [ ] Configurar CORS
- [ ] ¿Qué más?



## 📝 NOTAS ADICIONALES

**Preferencias de respuesta:**
- [ ] Explícame paso a paso con comandos exactos
- [ ] Incluye comentarios en el código


A partir de esto divídime el proyecto completo en 7 etapas, esto para yo poder ir poco a poco realizándolo y aprendiendo