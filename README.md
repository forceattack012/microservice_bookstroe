# microservice_bookstroe

# start redis
docker run --name bookstore-redis -dp 6370:6379 redis

# start mongo 
docker run --name some-mongo -dp 27017:27017 mongo