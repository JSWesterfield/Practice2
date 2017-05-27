using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stark.Data;
using Stark.Web.Services;
using Stark.Web.Models;
using Fundamentals.Models.Requests;

namespace Sabio.Web.Services
{
    public class FeaturesService : BaseService
    {
            public List<Feature> GetAll()
            {
                // in a service method that executes a SelectAll proc, we need to initialize a variable that will hold that entities that get back from our proc.
                List<Feature> list = null;

                Action<SqlParameterCollection> inputMapper = delegate (SqlParameterCollection parameters)
                {
                    // setup the parameters to the stored procedure

                    // in this particular case, Features_Select doens't have any parameters so this function remains empty.
                };

                Action<IDataReader, short> resultMapper = delegate (IDataReader reader, short set)
                {
                    // this function receives rows of data from our Select statement, and we will turn each row into an instance of our domain model.

                    // reader parameter to this function, represents one row of data.

                    Feature feature = new Feature();

                    // fill in the properties of our domain model in the same order that they're listed in the select clause.
                    //
                    // reader.Get{DataType}({index of the column you want})

                    //testEmployee.EmployeeId = reader.GetInt32(0);
                    //testEmployee.LastName = reader.GetString(1);
                    //testEmployee.FirstName = reader.GetString(2);
                    //testEmployee.Title = reader.GetString(3);

                    int startingIndex = 0;
                    feature.Id = reader.GetInt32(startingIndex++);
                    feature.Name = reader.GetString(startingIndex++);
                    feature.LocationId = reader.GetSafeInt32(startingIndex++);
                    feature.UserId = reader.GetInt32(startingIndex++);
                    feature.DateModified = reader.GetDateTime(startingIndex++);
                    feature.DateCreated = reader.GetDateTime(startingIndex++);

                    //no list exists, we create a new instance of the List array called list of our domain model class Feature.cs
                    if (list == null)
                    {
                        list = new List<Feature>();
                    }

                    //after our existing list or the new list array we create if list == null, we push our new instantied variable 'feature'
                    list.Add(feature);
                };

                //ADO.NET
                DataProvider.ExecuteCmd(
                    GetConnection,              //establish connection..
                    "dbo.Features_SelectAll",         //..to SQL server 
    
                    inputMapper,
                    resultMapper
                );

                return list;
            }
            // The Insert proc is much different than the SelectAll proc. First and foremost, it doesn't do a SELECT, so we don't use
            // DataProvider.ExecuteCmd. Also, the proc accepts a variety of parameters so we need to actually put some code into our
            // inputMapper callback function. Lastly, one of the parameters is an OUTPUT parameter (which enables the proc to send some
            // data back to C#) - this means we need to setup a returnMapper function. 
            // Step 1: create a request model. See FeatureCreateRequest.cs.

            // Step 2: setup your method. Create method will return and "int" in order to pass whatever id generated in SQL server to 
            // the calling code. we also require a parameter named "model" of our request model type:
            //          public int Create(TestEmployeeCreateRequest model) 
            //          {
            //              
            //          }

            // Step 3: declare a variable to hold the id value and iniitalize it to 0. add a "return" statement for this variable.
            // Step 4: just above the return statement, make the call to DataProvider.ExecuteNonQuery(). shis doesn't have a
            // resultMapper, it has a returnMapper.
            //          DataProvider.ExecuteNonQuery(GetConnection,
            //              {name of my proc},
            //              inputMapper,
            //              returnMapper);
            // Step 5: implement inputMapper and returnMapper (see below).
            public static int Create(FeatureCreateRequest model)
        {
            int id = 0;

            Action<SqlParameterCollection> inputMapper = delegate (SqlParameterCollection parameters)
             {
                //Name SQL Parameter, for my Create method
                SqlParameter nameParam = new SqlParameter("@Name", model.Name);
                 nameParam.Direction = ParameterDirection.Input;
                 parameters.Add(nameParam);

                //LocationId SQL Parameter, for my Create method
                SqlParameter locationIdParam = new SqlParameter("@LocationId", model.LocationId);
                 locationIdParam.Direction = ParameterDirection.Input;
                 parameters.Add(locationIdParam);

                //UserId SQL Parameter, for my Create method
                SqlParameter UserIdParam = new SqlParameter("@UserId", model.UserId);
                 UserIdParam.Direction = ParameterDirection.Input;
                 parameters.Add(UserIdParam);

                //Id SQL Parameter, for my Create method
                SqlParameter idParam = new SqlParameter("@id", id); // Notice the 2nd argument is just the "id" variable
                idParam.Direction = ParameterDirection.Output;          // and the direction is OUTPUT. This corresponds to 
                parameters.Add(idParam);                                // the "OUTPUT" keyword in our SQL proc parameter list.
            };

            // the point of the returnMapper is to retrieve the values of any OUTPUT parameters.
            Action<SqlParameterCollection> returnMapper = delegate (SqlParameterCollection parameters)
            {
                // we'll pretty much always be using this specific code in our returnMapper to get the generated Id:
                id = (int)parameters["@id"].Value;

            };

            DataProvider.ExecuteNonQuery(GetConnection,
                "dbo.Features_Insert",
                inputMapper,
                returnMapper);  //that returnMapper I was speaking of earlier, different from the above resultMapper.

            return id;
        }

        ////
        //public static void Update(FeaturesUpdateRequest model)
        //{
        //    //TODO: DataProvider setup
        //    Data
        //}

        //public static FeaturesService Get(int id)
        //{

        //}

        ////GETS Don't need a request model in the class method(GETALL) parameter as an argument.
        //public static List<FeaturesService> GetAll()
        //{

        //}
     }
}