# Sequence Diagram

```mermaid
sequenceDiagram

actor User

participant Console
participant ProductService
participant ProductRepository

User ->> Console: Add Product
Console ->> ProductService: AddProduct(name, price, quantity)
ProductService ->> ProductRepository: Add(product)
ProductRepository -->> ProductService: Product saved
ProductService -->> Console: Success
Console -->> User: Product added
```
