# min-api-with-mongo
Min API with MongoDB

## Docker Compose
docker compose up --build

## MongoDB Container starten
docker run
  --name mongodb
  -d
  -p 27017:27017
  -v data:/data/db -e MONGO_INITDB_ROOT_USERNAME=gbs
  -e MONGO_INITDB_ROOT_PASSWORD=geheim mongo

docker run --name mongodb -d -p 27017:27017 -v data:/data/db -e MONGO_INITDB_ROOT_USERNAME=gbs -e MONGO_INITDB_ROOT_PASSWORD=geheim mongo