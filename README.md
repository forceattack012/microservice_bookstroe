# microservice_bookstroe

# start redis
docker run --name bookstore-redis -dp 6370:6379 redis

# start mongo 
docker run --name book-mongo -dp 27017:27017 mongo

# start pg use network
docker run -d \
    --name bookstore-postgres \
    --network host \
    -e POSTGRES_DB=bookstore \
    -e POSTGRES_USER=admin \
    -e POSTGRES_PASSWORD=abcd1234 \
    -dp 5432:5432 \
    postgres

# start pg not use network
docker run -d \
    --name bookstore-postgres \
    -e POSTGRES_DB=bookstore \
    -e POSTGRES_USER=admin \
    -e POSTGRES_PASSWORD=abcd1234 \
    -dp 5432:5432 \
    postgres

# dotnet ef migration
 dotnet ef migrations add AddLookupTables