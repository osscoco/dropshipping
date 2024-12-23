Dropshipping (Angular / C# / Docker)
========================

L'application "Dropshipping (Angular / C# / Docker)" est une application servant de dropshipping entre les clients et les fournisseurs.

Docker
------------

- Pré requis :
    - Téléchargement : https://www.docker.com/ (Download For Windows - AMD64)
    - Installation ...
    - Vérification de la présence de docker et de docker compose (éxecution des commandes suivantes) :

```bash
$ docker --version
```

```bash
$ docker-compose --version
```

- Lancement du docker-compose :
    - Placement dans le dossier du fichier "docker-compose.yml" (./Docker/)
    - Execution (via le terminal de commande) de la commande suivante : 

```bash
$ docker-compose up
```

- Ouverture de PhpMyAdmin : 
    - Url : http://localhost:8080/
    - User : root
    - Password : 123456

- Accès à la base de données : dropshippingdb

GIT
------------

- Récupération du projet (remote vers local) :
    - Placement dans le dossier du fichier (./)
    - Execution (via le terminal de commande) de la commande suivante : 

```bash
$ git clone https://github.com/osscoco/dropshipping.git
```

ENVS
------------

- Ajout de la connectionString :
    - Ouverture du fichier "appsettings.json" dans le dossier (./Back C#/EFCore/)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;User id=root;Password=123456;Database=dropshippingdb;Persistsecurityinfo=True"
  }
}
```

- Ajout de la connectionString :
    - Ouverture du fichier "appsettings.json" dans le dossier (./Back C#/Dropshipping/)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;User id=root;Password=123456;Database=dropshippingdb;Persistsecurityinfo=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Jwt": {
    "Key": "St9v626b7NDeQ54kgtVis9byH488q2HUQXT23bNHSt9v626b7NDeQ54kgtVis9byH488q2HUQXT23bNH",
    "Issuer": "http://localhost:5180",
    "Audience": "http://localhost:5180",
    "Subject": "JwtSubject"
  }
}
```

MIGRATIONS
------------

- Lancement des migrations vers la base de données (PhpMyAdmin) :
    - Placement dans le dossier (./Back C#/EFCore/)
    - Execution (via le terminal de commande) de la commande suivante : 

```bash
$ dotnet tool install --global dotnet-ef
```
```bash
$ dotnet ef migrations add InitCreateTables
```
```bash
$ dotnet ef database update
```

API WEB
------------

- Lancement de l'API WEB :
    - Placement dans le dossier (./Back C#/API/)
    - Execution (via le terminal de commande) de la commande suivante : 

```bash
$ dotnet run
```

SWAGGER
------------

- Utilisation de l'interface SWAGGER : 
    - Url : http://localhost:8080/swagger/index.html
------------

README TEMPLATE FRONT
------------

# [Templatecookie](https://templatecookie.com)
Templatecookie.com creates quality templates and php scripts. Templatecookie has many free HTML & Figma templates available for professional use. Templatecookie is famous for its premium PHP Scripts available on [Codeanyon Marketplace](https://codecanyon.net/user/templatecookie). Browse [Templatecookie](https://templatecookie.com) today and discover awesome digital products.

# [Olog eCommerce Responsive HTML Template](https://olog-ecommerce-template.netlify.app/)

> Olog eCommerce Responsive HTML Template based on bootstrap framework v4.5.

This project is a bootstrap version [Olog eCommerce Responsive HTML Template](https://olog-ecommerce-template.netlify.app/) designed with HTML, CSS, SCSS, Bootstrap, Javascript & Jquery.

Check the [Live Demo here](https://olog-ecommerce-template.netlify.app/).

![](dist/images/screenshot.png)

## Technology We used
- HTML 5
- CSS 3
- SCSS 
- Bootstrap
- Fontawesome Icons 
- Javascript & jQuery
- Webpack 4
- Autoprefixer 

## Credits
- Design by coded by [Zakir Soft](https://zakirsoft.com)
- Fonts by Google Fonts - [Poppins](https://fonts.google.com/specimen/Poppins)
- Images from [Unsplash.com](http://unsplash.com)
- SVG Icons from [Feather Icons](https://feathericons.com)

## License
The MIT License (MIT). Please see [License File](LICENSE.md) for more information.

# Webpack Boilerplate
This repository contains Webpack and SCSS boilerplate code to quickly get started on building a webpage following a simplified version of SASS (7-1 pattern).


## Project Setup
### Installing
Run `npm install` to install all the dependencies this project needs. 

### Running the app
Run `npm run dev`. Your browser should automatically open a new tab where you can see your app.
*Note :* live reload is enabled so just modify your files and it will be reflected on the app instantly.

### Building the app
Run `npm run build`. It will automatically add vendor prefixes to CSS rules and compress all your `.scss` files into one `style.css` file located in your `dist` folder.


## SASS folder structure
It contains these folder and files : 

- `abstracts` : functions, variables
- `base` : reset, typography,
- `components` : buttons, form
- `layout` : footer, header, nav, breadcrumb
- `pages` : contact, home,
- `themes` : theme
- `vendors` : bootstrap, fontawesome

## Included Framework and Libraries
- `fontawesome` - Font Library

## Webpack Dependencies
- Webpack
- Babel
- File Loader
- CSS Loader
- Node SASS
- SASS Loader
- Post CSS 
- Autoprefixer
- Purge CSS
- Mini CSS Extractor Plugin




