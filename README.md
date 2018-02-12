When applying migrations uncomment seed method in StartUp.cs :

formContext.SeedData();

The API is accessed in the following manner :

http://localhost:52657/api/forms?SubmittedAfter=01/01/2018

http://localhost:52657/api/forms?SubmittedAfter=01/01/2018&MemberFirstName=Hans

http://localhost:52657/api/forms?SubmittedAfter=01/01/2018&submittedBefore=31/01/2018

http://localhost:52657/api/forms?submittedBefore=31/12/2017

http://localhost:52657/api/forms?IsProcessed=false

http://localhost:52657/api/forms?SearchBy?CaseWorker=Hansen&IsProcessed=false


Note the search parameters can be combined arbitrarily