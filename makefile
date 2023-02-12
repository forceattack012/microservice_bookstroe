register-kong:
	@curl -i -X POST http://localhost:8001/services --data name=book.api --data url="http://book.api:8080/"
	@curl -i -X POST http://localhost:8001/services --data name=basket.api --data url="http://basket.api:8081/"
	@curl -i -X POST http://localhost:8001/services --data name=order.api --data url="http://order.api:8082/"
	@curl -i -X POST http://localhost:8001/services/book.api/routes   --data "paths[]=/book"   --data name=book
	@curl -i -X POST http://localhost:8001/services/basket.api/routes   --data "paths[]=/basket"   --data name=basket
	@curl -i -X POST http://localhost:8001/services/order.api/routes   --data "paths[]=/order"   --data name=order