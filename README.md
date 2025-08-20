In this document I will discuss how I have approached the criteria

Data:

My approach with the data was to first normalize it. The reason for doing this is so that as the database grows, we can avoid unnecessary complications for example duplication and spelling errors. To normalize the data I first of all broke it down into different sections. This includes creating tables for specific information so we can have unique Ids to refer to, for example, horse, Jockey and Trainer. Splitting these up and giving them unique ids capture the relationship between these data points cleaner than just inputting all the data into one large table.  

Data struggles:

While working with the data, I have attempted to do a migration of the data, but there were some issues surrounding this, that I have struggled to resolve. 

Backend:

In the backend to capture my approach to data, I have created a model for each table and how we will be laying out information. Additionally, I have created a number of endpoints which can be used to get certain data from the database, as well as a POST endpoint so the owners can create notes about the particular race when they need to. We can add additional put or patch endpoint which we use to update notes, and can create a delete endpoint to delete notes no longer required. Or if a hard delete is not required we can just create an endpoint to archive. 

Front end:

I have attempted to make a frontend with Angular, utilising the assistance from ChatGPT as well as other online sources as I am unfamiliar with Angular and thought it would be a good learning exercise. Although I have made some good progress I am having trouble getting it running. I was attempting to create the table with the ability just for now to be able to search for races with horse ID and be able to add notes to particular races. Obviously this can be extended. 

Testing: 

My approach with testing is to have Xunit unit testing, with the addition of utilising SuperTest with cucumber to do some API acceptance testing for the different endpoints. With regard to frontend testing I would've liked to have utilised something like Cypress to do some testing or playwright which I think would have been good. I have attempted to get the tests working, locally but due to the issues with the data migration I cannot get acceptance tests working. I have added 1 unit test just as an example which is currently passing

Folder Structure:

I have created two projects, one for the API/ frontend and then one for testing. You can find all the information for the frontend in the API project under the folder race-owner-ui. I have tried to keep things as clean as possible, so I have seperated out the work as much as possible. 

Commands:

Just a brief note on the different commands.

API project: dotnet run
UI folder: npm start
Test project dotnet test





