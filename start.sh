echo -e '\x1b[1;5;97;43m Open the site at https://localhost \x1b[0m'

(
    export DatabaseConnection=$1
    echo $DatabaseConnection
    (cd Backend/Presentation-Kattencafe && dotnet watch ) &
    (cd Frontend-Klant/ && pnpm start --host --logLevel error) &
    (cd Frontend-Admin/ && pnpm start --host --logLevel error) &
    (./caddy.exe run ) ;	# > /dev/null 2>&1
kill 0)
