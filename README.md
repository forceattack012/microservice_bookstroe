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

# windows 
docker run -d --name bookstore-postgres -e POSTGRES_DB=bookstore -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=abcd1234 -dp 5432:5432 postgres

# dotnet ef migration
 dotnet ef migrations add InitialMigration

# remove migration
dotnet ef migrations remove

# generate migration to database 
 dotnet ef database update 

# ef drop 
 dotnet ef database drop  

# fix error Unable to create an object of type 'CustomerContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?link
 create DbContextFactory



# kong gateway 

 # 0 create networks 
docker network create bookstore-net
 # 1 prepare database
 docker run -d --name kong-database \
  --network=bookstore-net \
  -p 5432:5432 \
  -e "POSTGRES_USER=kong" \
  -e "POSTGRES_DB=kong" \
  -e "POSTGRES_PASSWORD=abcd1234" \
  postgres:13
 # 2 prepare kong database

docker run --rm --network=bookstore-net \
  -e "KONG_DATABASE=postgres" \
  -e "KONG_PG_HOST=kong-database" \
  -e "KONG_PG_PASSWORD=abcd1234" \
  -e "KONG_PASSWORD=test" \
  --platform linux/amd64 \
 kong/kong-gateway:3.1.1.3 "kong" migrations bootstrap

 # 3 start kong
docker run -d --name kong-gateway \
  --network=bookstore-net \
  -e "KONG_DATABASE=postgres" \
  -e "KONG_PG_HOST=kong-database" \
  -e "KONG_PG_USER=kong" \
  -e "KONG_PG_PASSWORD=abcd1234" \
  -e "KONG_PROXY_ACCESS_LOG=/dev/stdout" \
  -e "KONG_ADMIN_ACCESS_LOG=/dev/stdout" \
  -e "KONG_PROXY_ERROR_LOG=/dev/stderr" \
  -e "KONG_ADMIN_ERROR_LOG=/dev/stderr" \
  -e "KONG_ADMIN_LISTEN=0.0.0.0:8001" \
  -e "KONG_ADMIN_GUI_URL=http://localhost:9000" \
  -e KONG_LICENSE_DATA \
  -p 8000:8000 \
  -p 8443:8443 \
  -p 8001:8001 \
  -p 8444:8444 \
  -p 8002:8002 \
  -p 8445:8445 \
  -p 8003:8003 \
  -p 8004:8004 \
  --platform linux/amd64 \
  kong/kong-gateway:3.1.1.3

 # 4 verify its running
 curl -i http://localhost:8001/

 # 5 add service
 # 7001 internal port of docker
 curl -i -X POST http://localhost:8001/services --data name=book.api --data url="http://book.api:7001/" 

 # 6 add route
 curl -i -X POST http://localhost:8001/services/book.api/routes   --data "paths[]=/book-api"   --data name=book-api-route


# elasic search 
  # 1 
    docker network create elastic-net
  # 2
    docker run -d --name elasticsearch --network=elastic-net -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" docker.elastic.co/elasticsearch/elasticsearch:8.6.1
  # 3 
  docker run -d --name kibana --network=elastic-net -p 5601:5601 -e "ELASTICSEARCH_URL=http://elasticsearch:9200" docker.elastic.co/kibana/kibana:8.6.1
