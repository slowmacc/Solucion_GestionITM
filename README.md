# Solución Gestión ITM

Sistema integral de gestión desarrollado con una arquitectura modular y distribuida, diseñado para optimizar procesos académicos y administrativos.

## Estructura del Proyecto

El repositorio está organizado en los siguientes módulos principales:

* **`GestionITM.AppMovil`**: Aplicación cliente (desarrollada con tecnologías móviles / .NET MAUI) que incluye:
  * *Handlers*: Interceptores y manejadores de peticiones (ej. `AuthInterceptor.cs`).
  * *Views*: Vistas de la interfaz de usuario (ej. `CursosView.cs`).
  * *ViewModels*: Lógica de presentación y enlace de datos (ej. `CursosViewModel.cs`).
* **`GestionITM.Core`**: Núcleo de la solución que contiene la lógica de negocio central, interfaces (`IMatriculasService.cs`) y servicios compartidos (`MatriculasService.cs`).
* **`GestionITM.api`**: API Backend encargada de exponer los servicios y conectar con la capa de datos. Contiene controladores (ej. `MatriculaController.cs`).

## 🐳 Despliegue y Contenedores

El proyecto cuenta con soporte para contenedores mediante:
* `Dockerfile` para la paquetización de servicios.
* `docker-compose.yml` para la orquestación local de los componentes.

## 🚀 Tecnologías Utilizadas

* **C# / .NET** (para la API, Core y Aplicación Móvil).
* **Docker** (para la contenerización).
* Arquitectura limpia / separada por capas (API, Core, App Móvil).
