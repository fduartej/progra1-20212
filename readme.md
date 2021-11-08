## Fruto Seco APP venta de frutos secos (pasas, almendras, etc)

## parte 1 (setup del proyecto)

dotnet new mvc --auth Individual -o frutosecoapp

dotnet tool install --global dotnet-aspnet-codegenerator --version 5.0.2

dotnet aspnet-codegenerator identity -dc frutosecoapp.Data.ApplicationDbContext --files "Account.Register;Account.Login"

dotnet tool update --global dotnet-ef --version 5.0.9

Cambios de tipo de dato en la base datos de bit4 a bool
TwoFactorEnabled 
LockoutEnabled
EmailConfirmed
PhoneNumberConfirmed
Recomenda: Borrar el contenido de la carpeta Migrations (por defecto viene un clases)

dotnet ef migrations add InitialMigration --context frutosecoapp.Data.ApplicationDbContext -o "C:\Users\Inteligo\Code\netcore\usmp\programacionI\demomvc\frutosecoapp\Data\Migrations"

dotnet ef database update

## parte 2 (catalogo y ver producto)

dotnet ef migrations add DescripcionMigration --context frutosecoapp.Data.ApplicationDbContext -o "C:\Users\Inteligo\Code\netcore\usmp\programacionI\demomvc\frutosecoapp\Data\Migrations"

dotnet ef database update

## parte 2 (proforma)

dotnet ef migrations add ProformaMigration --context frutosecoapp.Data.ApplicationDbContext -o "C:\Users\Inteligo\Code\netcore\usmp\programacionI\demomvc\frutosecoapp\Data\Migrations"

## parte 3 (pago)

dotnet ef migrations add PagoMigration --context frutosecoapp.Data.ApplicationDbContext -o "C:\Users\Inteligo\Code\netcore\usmp\programacionI\demomvc\frutosecoapp\Data\Migrations"

## parte 4 (pedido)

dotnet ef migrations add PedidoMigration --context frutosecoapp.Data.ApplicationDbContext -o "C:\Users\Inteligo\Code\netcore\usmp\programacionI\demomvc\frutosecoapp\Data\Migrations"

## parte 5 (producto)

dotnet aspnet-codegenerator controller -name ProductController -m Product -dc frutosecoapp.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
