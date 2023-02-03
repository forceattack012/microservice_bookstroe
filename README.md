# microservice_bookstroe

# start redis
docker run --name bookstore-redis -dp 6370:6379 redis

# start mongo 
docker run --name book-mongo -dp 27017:27017 mongo

# start pg 
docker run --name bookstore-postgres -e POSTGRES_PASSWORD=abcd1234 -d postgres