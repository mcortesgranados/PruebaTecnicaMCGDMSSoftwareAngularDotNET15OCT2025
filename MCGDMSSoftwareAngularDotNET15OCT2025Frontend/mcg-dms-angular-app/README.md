# McgDmsAngularApp

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 19.2.18.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Karma](https://karma-runner.github.io) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.

```markdown
# Lugares App (Angular) - Ejemplo desde cero

File: README.md
Author: mcortesgranados

Esta app Angular realiza:
1. Login en POST /api/Auth/login (guarda token).
2. Llamada POST /api/Lugares/crear usando Authorization: Bearer <token>.

Requisitos:
- Node.js (>=14)
- npm
- Angular CLI (opcional, se usa a continuación)

Comandos rápidos para crear el proyecto y agregar archivos:

1. Instalar Angular CLI (si no lo tienes):
   npm install -g @angular/cli

2. Crear proyecto:
   ng new lugares-app --routing=false --style=css
   cd lugares-app

3. Generar componentes y servicios (opcional con CLI):
   ng generate component components/login --skip-tests
   ng generate component components/crear-lugar --skip-tests
   ng generate service services/auth --skip-tests
   ng generate service services/lugares --skip-tests
   mkdir -p src/app/interceptors

4. Reemplaza/pega los archivos proporcionados en las rutas indicadas:
   - src/environments/environment.ts
   - src/app/models/auth.model.ts
   - src/app/models/lugar.model.ts
   - src/app/services/auth.service.ts
   - src/app/services/lugares.service.ts
   - src/app/interceptors/token.interceptor.ts
   - src/app/components/login/login.component.ts
   - src/app/components/login/login.component.html
   - src/app/components/crear-lugar/crear-lugar.component.ts
   - src/app/components/crear-lugar/crear-lugar.component.html
   - src/app/app.component.ts
   - src/app/app.component.html
   - src/app/app.module.ts

5. Instala dependencias y arranca:
   npm install
   ng serve

6. Abre en el navegador:
   http://localhost:4200

Notas importantes:
- Asegúrate de que tu API permita CORS desde http://localhost:4200.
- No guardes tokens en localStorage en aplicaciones altamente sensibles sin evaluar riesgos. Para mayor seguridad, considera cookies HttpOnly o un flujo con refresh tokens.
- Si tu back-end devuelve errores específicos en el body (por ejemplo message), puedes mejorar el manejo de errores para mostrarlos al usuario.
- Si quieres, puedo añadir:
  - Rutas protegidas (Guards) y redirecciones.
  - Manejo de refresh token y expiración automática.
  - Tests unitarios.
  - Un ejemplo con almacenamiento seguro (cookies HttpOnly) si tu backend lo soporta.
```
