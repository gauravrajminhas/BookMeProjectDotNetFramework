Doubts:- 
    1. how and when To dispose of the dbContext correctly? 
    





Challenges Faced
    1. Poco serialization with navigation properties 
        -Implemented DTOs and AutoMapper
        
    2. LifeTime and management of DBContext 
		- Thread Safe Exception when using singleton method for DB context
			The context cannot be used while the model is being created. This exception may be thrown if the context is used inside the OnModelCreating method or if the same context instance is accessed by multiple threads concurrently. Note that instance members of DbContext and related classes are not guaranteed to be thread safe.

    3. The application goes in maintenance mode and thus only Reads and no writes 
        - Segregated Read from writes  using CQSP


	4. Implement Transaction for complex business Activities 
		- Implement Resource Manager 
		- Impliment Transaction Manager 
		- Implement a 2-stage Commit
		

	5. Multi-Db Context Implementation 


Research 
	1. Database Isolation levels & transactions support 
	2. transaction isolation level