# KodlamaIoDevs
This project is to train Senior .Net Core Developer by Kodlama.io


This project includes programming languages in order to add, update, delete and get.

It has CQRS approach by dividing the command and queries. For that, MediatR package is used.

Commands in the my file directory:
  * CreateProgrammingLanguage
  * UpdateProgrammingLanguage
  * DeleteProgrammingLanguage
  
All of them have validators utilizing the FluentValidation package.

Queries in the my file directory:
  * GetByIdProgrammingLanguage
  * GetListProgrammingLanguage
  
 In addition, the bussiness rules was defined in the different file because of the Single Responsibility Pattern. 


AutoMapper package is used for mapping among models.

# File Directory of the Application layer
![Screenshot_1](https://user-images.githubusercontent.com/56292618/188316588-faf3c6f0-aad4-462d-912a-0f6c5f3b0ead.png)

