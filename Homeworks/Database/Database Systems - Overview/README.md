#Homework

Answer following questions in Markdown format (.md file)

###1. What database models do you know?
####Hierarchical (tree)
A [tree structure](https://en.wikipedia.org/wiki/Tree_structure) or tree diagram is a way of representing the hierarchical nature of a structure in a graphical form. It is named a "tree structure" because the classic representation resembles a tree, even though the chart is generally upside down compared to an actual tree, with the "root" at the top and the "leaves" at the bottom.

A tree structure is conceptual, and appears in several forms. For a discussion of tree structures in specific fields, see Tree (data structure) for computer science: insofar as it relates to graph theory, see tree (graph theory), or also tree (set theory). Other related pages are listed below.

#####Network / graph
The [Network Graph](https://en.wikipedia.org/wiki/Graph_database) visualization supports undirected and directed graph structures. This type of visualization illuminates relationships between entities. Entities are displayed as round nodes and lines show the relationships between them. The vivid display of network nodes can highlight non-trivial data discrepancies that may be otherwise be overlooked.

#####Relational 
A [relational database](https://en.wikipedia.org/wiki/Relational_database) is a digital database whose organization is based on the relational model of data, as proposed by E.F. Codd in 1970. This model organizes data into one or more tables (or "relations") of rows and columns, with a unique key for each row.

#####Object-oriented
An [object database](https://en.wikipedia.org/wiki/Object_database) (also object-oriented database management system) is a database management system in which information is represented in the form of objects as used in object-oriented programming. Object databases are different from relational databases which are table-oriented.
	
###2. Which are the main functions performed by a Relational Database Management System (RDBMS)?
 * Creating / altering / deleting tables and relationships between them (database schema)
 * Adding, changing, deleting, searching and retrieving of data stored in the tables
 * Support for the SQL language
 * Transaction management (optional)

###3. Define what is "table" in database terms.
A table is a collection of related data held in a structured format within a database. It consists of fields (columns), and rows. Read more [here](https://en.wikipedia.org/wiki/Table_(database)).

###4. Explain the difference between a primary and a foreign key.
[Primary key](https://www.techopedia.com/definition/5547/primary-key) is a column of the table that uniquely identifies its rows (usually its is a number).
The [foreign key](https://en.wikipedia.org/wiki/Foreign_key) is an identifier of a record located in another table (usually the other table's primary key).

###5. Explain the different kinds of relationships between tables in relational databases.
####[One-to-many](http://www.databaseprimer.com/pages/relationship_1tox/)
In a one-to-many relationship, each row in the related to table can be related to many rows in the relating table. This allows frequently used information to be saved only once in a table and referenced many times in all other tables. In a one-to-many relationship between Table A and Table B, each row in Table A is linked to 0, 1 or many rows in Table B. The number of rows in Table A is almost always less than the number of rows in Table B.

####[Many-to-many](http://www.databaseprimer.com/pages/relationship_xtox/)
In a many-to-many relationship, one or more rows in a table can be related to 0, 1 or many rows in another table. In a many-to-many relationship between Table A and Table B, each row in Table A is linked to 0, 1 or many rows in Table B and vice versa. A 3rd table called a mapping table is required in order to implement such a relationship.

####[One-to-one](http://www.databaseprimer.com/pages/relationship_1to1/)
In a one-to-one relationship, each row in one database table is linked to 1 and only 1 other row in another table. In a one-to-one relationship between Table A and Table B, each row in Table A is linked to another row in Table B. The number of rows in Table A must equal the number of rows in Table B.

###6. When is a certain database schema normalized?
[Database normalization](https://en.wikipedia.org/wiki/Database_normalization) (or normalisation) is the process of organizing the columns (attributes) and tables (relations) of a relational database to minimize data redundancy.

###7. What are the advantages of normalized databases?
 1. To free the collection of relations from undesirable insertion, update and deletion dependencies;
 2. To reduce the need for restructuring the collection of relations, as new types of data are introduced, and thus increase  the life span of application programs;
 3. To make the relational model more informative to users;
 4. To make the collection of relations neutral to the query statistics, where these statistics are liable to change as time goes by.

###8. What are database integrity constraints and when are they used?
[Integrity constraints](https://en.wikipedia.org/wiki/Data_integrity) provide a mechanism for ensuring that data conforms to guidelines specified by the database administrator.

###9. Point out the pros and cons of using indexes in a database.
####Advantages
Use an index for quick access to a database table specific information. The index is a structure of the database table the value of one or more columns to sort
As a general rule, only when the data in the index column Frequent queries, only need to create an index on the table. The index take up disk space and reduce to add, delete, and update the line speed. In most cases, the speed advantages of indexes for data retrieval greatly exceeds it. 
####Disadvantages
Indexing will affect the speed of update and insert, because it requires the same update each index file. For a frequently updated and inserted into the table, there is no need for a rarely used where the words indexed separately, small table, the cost of sorting will not be great, there is no need to create additional indexes. In some cases, the indexing words may not be fast, for example, the index is placed in a contiguous memory space, which will increase the burden of disk read, which is optimal, it should be through the actual use of the environment to be tested.

###10. What's the main purpose of the SQL language?
[SQL](https://en.wikipedia.org/wiki/SQL) supports:
 * Creating, altering, deleting tables and other objects in the database
 * Searching, retrieving, inserting, modifying and deleting table data (rows)

###11. What are transactions used for?
[Transactions](https://msdn.microsoft.com/en-us/library/ms174377.aspx) are a sequence of database operations which are executed as a single unit:
 * Either all of them execute successfully
 * Or none of them is executed at all

###12. Give an example.

Consider the CUSTOMERS table having the following records:

	+----+----------+-----+-----------+----------+
	| ID | NAME     | AGE | ADDRESS   | SALARY   |
	+----+----------+-----+-----------+----------+
	|  1 | Pesho    |  32 | Sofia     |  2000.00 |
	|  2 | Gosho    |  25 | Pernik    |  1500.00 |
	|  3 | Mariq    |  23 | Kaspichan |  2000.00 |
	|  4 | Mitko    |  25 | Varna     |  6500.00 |
	|  5 | Penka    |  27 | Burgas    |  8500.00 |
	|  6 | Monika   |  22 | Tarnovo   |  4500.00 |
	|  7 | Simona   |  24 | Etropole  | 10000.00 |
	+----+----------+-----+-----------+----------+
	
Following is the example which would delete records from the table having age = 25 and then COMMIT the changes in the database.

	DELETE FROM CUSTOMERS
	WHERE AGE = 25;
	COMMIT;
	
As a result, two rows from the table would be deleted and SELECT statement would produce the following result:

	+----+----------+-----+-----------+----------+
	| ID | NAME     | AGE | ADDRESS   | SALARY   |
	+----+----------+-----+-----------+----------+
	|  1 | Pesho    |  32 | Sofia     |  2000.00 |
	|  3 | Mariq    |  23 | Kaspichan |  2000.00 |
	|  5 | Penka    |  27 | Burgas    |  8500.00 |
	|  6 | Monika   |  22 | Tarnovo   |  4500.00 |
	|  7 | Simona   |  24 | Etropole  | 10000.00 |
	+----+----------+-----+-----------+----------+
####The ROLLBACK Command:
The ROLLBACK command is the transactional command used to undo transactions that have not already been saved to the database.

The ROLLBACK command can only be used to undo transactions since the last COMMIT or ROLLBACK command was issued.
	
Consider the CUSTOMERS table having the following records:

	+----+----------+-----+-----------+----------+
	| ID | NAME     | AGE | ADDRESS   | SALARY   |
	+----+----------+-----+-----------+----------+
	|  1 | Pesho    |  32 | Sofia     |  2000.00 |
	|  2 | Gosho    |  25 | Pernik    |  1500.00 |
	|  3 | Mariq    |  23 | Kaspichan |  2000.00 |
	|  4 | Mitko    |  25 | Varna     |  6500.00 |
	|  5 | Penka    |  27 | Burgas    |  8500.00 |
	|  6 | Monika   |  22 | Tarnovo   |  4500.00 |
	|  7 | Simona   |  24 | Etropole  | 10000.00 |
	+----+----------+-----+-----------+----------+
	
Following is the example, which would delete records from the table having age = 25 and then ROLLBACK the changes in the database.

	DELETE FROM CUSTOMERS
	WHERE AGE = 25;
	ROLLBACK;
	
As a result, delete operation would not impact the table and SELECT statement would produce the following result:

	+----+----------+-----+-----------+----------+
	| ID | NAME     | AGE | ADDRESS   | SALARY   |
	+----+----------+-----+-----------+----------+
	|  1 | Pesho    |  32 | Sofia     |  2000.00 |
	|  2 | Gosho    |  25 | Pernik    |  1500.00 |
	|  3 | Mariq    |  23 | Kaspichan |  2000.00 |
	|  4 | Mitko    |  25 | Varna     |  6500.00 |
	|  5 | Penka    |  27 | Burgas    |  8500.00 |
	|  6 | Monika   |  22 | Tarnovo   |  4500.00 |
	|  7 | Simona   |  24 | Etropole  | 10000.00 |
	+----+----------+-----+-----------+----------+
	
####The SAVEPOINT Command:
A SAVEPOINT is a point in a transaction when you can roll the transaction back to a certain point without rolling back the entire transaction.
	
This command serves only in the creation of a SAVEPOINT among transactional statements. The ROLLBACK command is used to undo a group of transactions.
	
Following is an example where you plan to delete the three different records from the CUSTOMERS table. You want to create a SAVEPOINT before each delete, so that you can ROLLBACK to any SAVEPOINT at any time to return the appropriate data to its original state:

Consider the CUSTOMERS table having the following records:

	+----+----------+-----+-----------+----------+
	| ID | NAME     | AGE | ADDRESS   | SALARY   |
	+----+----------+-----+-----------+----------+
	|  1 | Pesho    |  32 | Sofia     |  2000.00 |
	|  2 | Gosho    |  25 | Pernik    |  1500.00 |
	|  3 | Mariq    |  23 | Kaspichan |  2000.00 |
	|  4 | Mitko    |  25 | Varna     |  6500.00 |
	|  5 | Penka    |  27 | Burgas    |  8500.00 |
	|  6 | Monika   |  22 | Tarnovo   |  4500.00 |
	|  7 | Simona   |  24 | Etropole  | 10000.00 |
	+----+----------+-----+-----------+----------+
	
Now, here is the series of operations:

	SQL> SAVEPOINT SP1;
	Savepoint created.
	SQL> DELETE FROM CUSTOMERS WHERE ID=1;
	1 row deleted.
	SQL> SAVEPOINT SP2;
	Savepoint created.
	SQL> DELETE FROM CUSTOMERS WHERE ID=2;
	1 row deleted.
	SQL> SAVEPOINT SP3;
	Savepoint created.
	SQL> DELETE FROM CUSTOMERS WHERE ID=3;
	1 row deleted.

Now that the three deletions have taken place, say you have changed your mind and decided to ROLLBACK to the SAVEPOINT that you identified as SP2. Because SP2 was created after the first deletion, the last two deletions are undone:
	
	SQL> ROLLBACK TO SP2;
	Rollback complete.
	
Notice that only the first deletion took place since you rolled back to SP2:

	SQL> SELECT * FROM CUSTOMERS;

	+----+----------+-----+-----------+----------+
	| ID | NAME     | AGE | ADDRESS   | SALARY   |
	+----+----------+-----+-----------+----------+
	|  2 | Khilan   |  25 | Delhi     |  1500.00 |
	|  3 | kaushik  |  23 | Kota      |  2000.00 |
	|  4 | Chaitali |  25 | Mumbai    |  6500.00 |
	|  5 | Hardik   |  27 | Bhopal    |  8500.00 |
	|  6 | Komal    |  22 | MP        |  4500.00 |
	|  7 | Muffy    |  24 | Indore    | 10000.00 |
	+----+----------+-----+-----------+----------+
	
	6 rows selected.
	
####The RELEASE SAVEPOINT Command:
The RELEASE SAVEPOINT command is used to remove a SAVEPOINT that you have created.

Once a SAVEPOINT has been released, you can no longer use the ROLLBACK command to undo transactions performed since the SAVEPOINT.

####The SET TRANSACTION Command:
The SET TRANSACTION command can be used to initiate a database transaction. This command is used to specify characteristics for the transaction that follows.

For example, you can specify a transaction to be read only, or read write.

###13. What is a NoSQL database?
A [NoSQL](https://en.wikipedia.org/wiki/NoSQL) (originally referring to "non SQL" or "non relational") database provides a mechanism for storage and retrieval of data that is modeled in means other than the tabular relations used in relational databases. Such databases have existed since the late 1960s, but did not obtain the "NoSQL" moniker until a surge of popularity in the early twenty-first century, triggered by the needs of Web 2.0 companies such as Facebook, Google and Amazon.com.

###14. Explain the classical non-relational data models.
[Explaining relational and non-relational data models to your mom](http://www.ignoredbydinosaurs.com/2013/05/explaining-non-relational-databases-my-mom)

###15. Give few examples of NoSQL databases and their pros and cons.

####Pros:

 * Mostly open source.
 * Horizontal scalability. There’s no need for complex joins and data can be easily sharded and processed in parallel.
 * Support for Map/Reduce. This is a simple paradigm that allows for scaling computation on cluster of computing nodes.
 * No need to develop fine-grained data model – it saves development time.
 * Easy to use.
 * Very fast for adding new data and for simple operations/queries.
 * No need to make significant changes in code when data structure is modified.
 * Ability to store complex data types (for document based solutions) in a single item of storage.

####Cons:

 * Immaturity. Still lots of rough edges.
 * Possible database administration issues. NoSQL often sacrifices features that are present in SQL solutions “by default” for the sake of performance. For example, one needs to check different data durability modes and journaling in order not to be caught by surprise after a cold restart of the system. Memory consumption is one more important chapter to read up on in the database manual because memory is usually heavily used.
 * No indexing support (Some solutions like MongoDB have indexing but it’s not as powerful as in SQL solutions).
 * No ACID (Some solutions have just atomicity support on single object level).
 * Bad reporting performance.
 * Complex consistency models (like eventual consistency). CAP theorem states that it’s not possible to achieve consistency, availability and partitioning tolerance at the same time. NoSQL vendors are trying to make their solutions as fast as possible and consistency is most typical trade-off.
 * Absence of standardization. No standard APIs or query language. It means that migration to a solution from different vendor is more costly. Also there are no standard tools (e.g. for reporting)
 
#Thumbs up for everyone who managed to read this whole file
	
	░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
	░░░░░░░▄▄▀▀▀▀▀▀▀▀▀▀▄▄█▄░░░░▄░░░░█░░░░░░░
	░░░░░░█▀░░░░░░░░░░░░░▀▀█▄░░░▀░░░░░░░░░▄░
	░░░░▄▀░░░░░░░░░░░░░░░░░▀██░░░▄▀▀▀▄▄░░▀░░
	░░▄█▀▄█▀▀▀▀▄░░░░░░▄▀▀█▄░▀█▄░░█▄░░░▀█░░░░
	░▄█░▄▀░░▄▄▄░█░░░▄▀▄█▄░▀█░░█▄░░▀█░░░░█░░░
	▄█░░█░░░▀▀▀░█░░▄█░▀▀▀░░█░░░█▄░░█░░░░█░░░
	██░░░▀▄░░░▄█▀░░░▀▄▄▄▄▄█▀░░░▀█░░█▄░░░█░░░
	██░░░░░▀▀▀░░░░░░░░░░░░░░░░░░█░▄█░░░░█░░░
	██░░░░░░░░░░░░░░░░░░░░░█░░░░██▀░░░░█▄░░░
	██░░░░░░░░░░░░░░░░░░░░░█░░░░█░░░░░░░▀▀█▄
	██░░░░░░░░░░░░░░░░░░░░█░░░░░█░░░░░░░▄▄██
	░██░░░░░░░░░░░░░░░░░░▄▀░░░░░█░░░░░░░▀▀█▄
	░▀█░░░░░░█░░░░░░░░░▄█▀░░░░░░█░░░░░░░▄▄██
	░▄██▄░░░░░▀▀▀▄▄▄▄▀▀░░░░░░░░░█░░░░░░░▀▀█▄
	░░▀▀▀▀░░░░░░░░░░░░░░░░░░░░░░█▄▄▄▄▄▄▄▄▄██
	░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
