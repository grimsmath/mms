using MMS.Helpers;
using MMS.Models;
using MMS.Providers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace MMS.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MMS.DAO.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// This method is called when executing a database-update command from the Package
        /// Manager Console.
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(MMS.DAO.ApplicationContext context)
        {
            // ================================================================================
            // Domain Configuration Values
            // ================================================================================
            GetDomains().ForEach(e => context.Domains.AddOrUpdate(e));

            // ================================================================================
            // States of the Union
            // ================================================================================
            GetStates().ForEach(e => context.States.AddOrUpdate(e));

            // ================================================================================
            // User Roles
            // ================================================================================
            GetUserRoles().ForEach(e => context.UserRoles.AddOrUpdate(e));

            // ================================================================================
            // User Profiles & Xref
            // ================================================================================
            GetUserProfiles().ForEach(e => context.UserProfiles.AddOrUpdate(e));
            GetUsersInRoles().ForEach(e => context.UserInRoles.AddOrUpdate(e));

            // ================================================================================
            // Addresses
            // ================================================================================
            GetAddresses().ForEach(e => context.Addresses.AddOrUpdate(e));
            GetAddressXRef().ForEach(e => context.PersonToAddress.AddOrUpdate(e));

            // ================================================================================
            // People
            // ================================================================================            
            GetPeople().ForEach(e => context.People.AddOrUpdate(e));

            // ================================================================================
            // Ministries
            // ================================================================================
            GetMinistries().ForEach(e => context.Ministries.AddOrUpdate(e));

            // ================================================================================
            // Mentor Applications
            // ================================================================================
            GetApplications().ForEach(e => context.MentorApplications.AddOrUpdate(e));

            // ================================================================================
            // User Messages
            // ================================================================================
            GetMessages().ForEach(e => context.Messages.AddOrUpdate(e));

            // ================================================================================
            // Calendar Events
            // ================================================================================
            GetEvents().ForEach(e => context.Events.AddOrUpdate(e));
        }

        /// <summary>
        /// These are the system configuration values typically considered "Domain" values
        /// </summary>
        /// <returns>List<Domain></returns>
        private static List<Domain> GetDomains()
        {
            var domains = new List<Domain>
			{
                // ================================================================================
				// Prefixes
                // ================================================================================
				new Domain { id = 01,   Key = "Prefix",         Value = "Mr" },
				new Domain { id = 02,   Key = "Prefix",         Value = "Mrs" },
				new Domain { id = 03,   Key = "Prefix",         Value = "Ms" },
				new Domain { id = 04,   Key = "Prefix",         Value = "Dr" },

                // ================================================================================
				// Suffixes
                // ================================================================================
				new Domain { id = 05,   Key = "Suffix",         Value = "Sr" },
				new Domain { id = 06,   Key = "Suffix",         Value = "Jr" },
				new Domain { id = 07,   Key = "Suffix",         Value = "I" },
				new Domain { id = 08,   Key = "Suffix",         Value = "II" },
				new Domain { id = 09,   Key = "Suffix",         Value = "III" },
				new Domain { id = 10,   Key = "Suffix",         Value = "IV" },
				new Domain { id = 11,   Key = "Suffix",         Value = "V" },
				new Domain { id = 12,   Key = "Suffix",         Value = "PhD" },
				new Domain { id = 13,   Key = "Suffix",         Value = "MD" },
				new Domain { id = 14,   Key = "Suffix",         Value = "EdD" },

                // ================================================================================
				// Genders
                // ================================================================================
				new Domain { id = 15,   Key = "Gender",         Value = "Male" },
				new Domain { id = 16,   Key = "Gender",         Value = "Female" },

                // ================================================================================
				// Races
                // ================================================================================
				new Domain { id = 17,   Key = "Race",           Value = "American Indian or Alaskan Native" },
				new Domain { id = 18,   Key = "Race",           Value = "Asian or Pacific Islander" },
				new Domain { id = 19,   Key = "Race",           Value = "Black" },
				new Domain { id = 20,   Key = "Race",           Value = "White" },
				new Domain { id = 21,   Key = "Race",           Value = "Unknown" },

                // ================================================================================
				// Contact Types
                // ================================================================================
				new Domain { id = 22,   Key = "ContactType",    Value = "In Person" },
				new Domain { id = 23,   Key = "ContactType",    Value = "Via Phone" },
				new Domain { id = 24,   Key = "ContactType",    Value = "Via Email" },

                // ================================================================================
				// Event Types
                // ================================================================================
				new Domain { id = 25,   Key = "EventType",      Value = "Public" },
				new Domain { id = 26,   Key = "EventType",      Value = "Training" },
				new Domain { id = 27,   Key = "EventType",      Value = "Mentee Meeting Request" },
				new Domain { id = 28,   Key = "EventType",      Value = "Mentor Meeting Request" },

                // ================================================================================
				// Resource Types
                // ================================================================================
				new Domain { id = 29,   Key = "ResourceType",   Value = "Document" },
				new Domain { id = 30,   Key = "ResourceType",   Value = "Spreadsheet" },
				new Domain { id = 31,   Key = "ResourceType",   Value = "PDF" },
				new Domain { id = 32,   Key = "ResourceType",   Value = "Graphic" },
				new Domain { id = 33,   Key = "ResourceType",   Value = "Text File" },
				new Domain { id = 34,   Key = "ResourceType",   Value = "Program File" },
				new Domain { id = 35,   Key = "ResourceType",   Value = "Binary File" },
				new Domain { id = 36,   Key = "ResourceType",   Value = "Unknown File Type" },

                // ================================================================================
				// Status Codes
                // ================================================================================
				new Domain { id = 37,   Key = "StatusCode",     Value = "Active" },
				new Domain { id = 38,   Key = "StatusCode",     Value = "Inactive" },
				new Domain { id = 39,   Key = "StatusCode",     Value = "Disabled" },
				new Domain { id = 40,   Key = "StatusCode",     Value = "Deleted" },
				new Domain { id = 41,   Key = "StatusCode",     Value = "On Hold" },
				new Domain { id = 42,   Key = "StatusCode",     Value = "Pending" },
				new Domain { id = 43,   Key = "StatusCode",     Value = "Declined" },
				new Domain { id = 44,   Key = "StatusCode",     Value = "Deferred" },
				new Domain { id = 45,   Key = "StatusCode",     Value = "Awaiting Approval" },
				new Domain { id = 46,   Key = "StatusCode",     Value = "Awaiting Paperwork" },
				new Domain { id = 47,   Key = "StatusCode",     Value = "New Registration" },
				new Domain { id = 48,   Key = "StatusCode",     Value = "Reactivated Registration" },
				new Domain { id = 49,   Key = "StatusCode",     Value = "Renewal Registration" },

                // ================================================================================
                // Person Types 
                // ================================================================================
                // (not to be confused with UserRole, UserRoles are security identifiers whereas 
                // Person Types are just to identify the type of person record
                // ================================================================================
                new Domain { id = 50,   Key = "PersonType",     Value = "Mentor" },
                new Domain { id = 51,   Key = "PersonType",     Value = "Lead Mentor" },
                new Domain { id = 52,   Key = "PersonType",     Value = "Head Mentor" },
                new Domain { id = 53,   Key = "PersonType",     Value = "JREC Staff" },
                new Domain { id = 54,   Key = "PersonType",     Value = "Chaplain" },
                new Domain { id = 55,   Key = "PersonType",     Value = "Mentee" },
                new Domain { id = 56,   Key = "PersonType",     Value = "Minister" },
                new Domain { id = 57,   Key = "PersonType",     Value = "Director" },
                new Domain { id = 58,   Key = "PersonType",     Value = "Coordinator" },
                new Domain { id = 59,   Key = "PersonType",     Value = "Parole Officer" },
                new Domain { id = 60,   Key = "PersonType",     Value = "Deputy Sheriff" },
                new Domain { id = 61,   Key = "PersonType",     Value = "Police Officer" },
                new Domain { id = 62,   Key = "PersonType",     Value = "Corrections Officer" },
                new Domain { id = 63,   Key = "PersonType",     Value = "Volunteer" },
                new Domain { id = 64,   Key = "PersonType",     Value = "Guest" },

                // ================================================================================
                // Address Types
                // ================================================================================
                new Domain { id = 65,   Key = "AddressType",     Value = "Home" },
                new Domain { id = 66,   Key = "AddressType",     Value = "Work" },
                new Domain { id = 67,   Key = "AddressType",     Value = "Shelter" },
                new Domain { id = 68,   Key = "AddressType",     Value = "Facility" },
                
                // ================================================================================
                // Phone Types
                // ================================================================================
                new Domain { id = 69,   Key = "PhoneType",       Value = "Home" },
                new Domain { id = 70,   Key = "PhoneType",       Value = "Work" },
                new Domain { id = 71,   Key = "PhoneType",       Value = "Cell" },
                new Domain { id = 72,   Key = "PhoneType",       Value = "Fax" },
			};

            return domains;
        }

        private static List<UserRole> GetUserRoles()
        {
            var roles = new List<UserRole>
			{
				new UserRole { id = 1, Name = "Administrator" },
				new UserRole { id = 2, Name = "JREC Staff" },
				new UserRole { id = 3, Name = "Head Mentor" },
				new UserRole { id = 4, Name = "Lead Mentor" },
				new UserRole { id = 5, Name = "Mentor" },
				new UserRole { id = 6, Name = "Mentee" },
				new UserRole { id = 7, Name = "Chaplain" },
				new UserRole { id = 8, Name = "Guest" }
			};

            return roles;
        }

        static List<UserProfile> GetUserProfiles()
        {
            string salt = CryptHelper.CreateSalt(256);

            var profiles = new List<UserProfile>
			{
				new UserProfile
				{
					id = 1,
					Username = "admin",
					Password = CryptHelper.CreatePasswordHash("password", salt),
					Salt = salt,
					PersonId = 1,   // David King
                    CanBeDeleted = false,
                    SecurityQuestion = "What is your cat's name?",
                    SecurityAnswer = CryptHelper.CreatePasswordHash("Precious", salt)
				},
                new UserProfile
                {
                    id = 2,
                    Username = "mentor",
                    Password = CryptHelper.CreatePasswordHash("password", salt),
                    Salt = salt,
                    PersonId = 2,   // Bob Roggio
                    CanBeDeleted = false,
                    SecurityQuestion = "What is your cat's name?",
                    SecurityAnswer = CryptHelper.CreatePasswordHash("Gabbie", salt)
                },
                new UserProfile
                {
                    id = 3,
                    Username = "chaplain",
                    Password = CryptHelper.CreatePasswordHash("password", salt),
                    Salt = salt,
                    PersonId = 2,   // Carly Pellegrini
                    CanBeDeleted = false,
                    SecurityQuestion = "What is your mother's maiden name?",
                    SecurityAnswer = CryptHelper.CreatePasswordHash("Ray", salt)
                }
			};

            return profiles;
        }

        private static List<Person> GetPeople()
        {
            var people = new List<Person>
            {
                new Person
                {
                    id = 1,
                    PersonTypeId = 53, // JREC Staff
                    PrefixId = 1, // Mr
                    FirstName = "David",
                    MiddleInitial = "P",
                    LastName = "King",
                    SuffixId = 6, // Jr
                    DOB = DateTime.Parse("01/21/1976"),
                    MisdemeanorArrested = 0,
                    MisdemeanorConvicted = 0,
                    FelonyArrested = 0,
                    FelonyConvicted = 0,
                    RaceId = 20, // white
                    GenderId = 15, // male
                    SSN = "111-11-1111",
                    StateDl = "K111-111-11-111-1",
                    StateWhereDlWasIssued = "FL", // Florida
                },
                new Person
                {
                    id = 2,
                    PersonTypeId = 51, // Lead Mentor
                    PrefixId = 1, // Mr
                    FirstName = "Bob",
                    MiddleInitial = "",
                    LastName = "Roggio",
                    SuffixId = 0, // None
                    DOB = DateTime.Parse("05/05/1969"),
                    MisdemeanorArrested = 0,
                    MisdemeanorConvicted = 0,
                    FelonyArrested = 0,
                    FelonyConvicted = 0,
                    RaceId = 20, // White
                    GenderId = 15, // Male
                    SSN = "222-22-2222",
                    StateDl = "R222-222-22-222-2",
                    StateWhereDlWasIssued = "FL", // Florida
                },
                new Person
                {
                    id = 3,
                    PersonTypeId = 54, // Chaplain
                    PrefixId = 3, // Ms
                    FirstName = "Carly",
                    MiddleInitial = "",
                    LastName = "Pellegrini",
                    SuffixId = 0, // None
                    DOB = DateTime.Parse("01/01/1989"),
                    MisdemeanorArrested = 0,
                    MisdemeanorConvicted = 0,
                    FelonyArrested = 0,
                    FelonyConvicted = 0,
                    RaceId = 20, // White
                    GenderId = 16, // Female
                    SSN = "333-33-3333",
                    StateDl = "P333-333-33-333-3",
                    StateWhereDlWasIssued = "FL", // Florida
                },
                new Person
                {
                    id = 4,
                    PersonTypeId = 50, // Mentor
                    PrefixId = 1, // Mr
                    FirstName = "Cassedy",
                    MiddleInitial = "",
                    LastName = "Conant",
                    SuffixId = 0, // None
                    DOB = DateTime.Parse("02/01/1989"),
                    MisdemeanorArrested = 0,
                    MisdemeanorConvicted = 0,
                    FelonyArrested = 0,
                    FelonyConvicted = 0,
                    RaceId = 20, // White
                    GenderId = 15, // Male
                    SSN = "444-44-4444",
                    StateDl = "C444-444-44-444-4",
                    StateWhereDlWasIssued = "FL", // Florida
                },
                new Person
                {
                    id = 5,
                    PersonTypeId = 55, // Mentee
                    PrefixId = 1, // Mr
                    FirstName = "John",
                    MiddleInitial = "",
                    LastName = "Doe",
                    SuffixId = 0, // None
                    DOB = DateTime.Parse("01/01/1969"),
                    MisdemeanorArrested = 1,
                    MisdemeanorConvicted = 1,
                    FelonyArrested = 1,
                    FelonyConvicted = 1,
                    RaceId = 19, // Black
                    GenderId = 15, // Male
                    SSN = "555-55-5555",
                    StateDl = "D555-555-55-555-5",
                    StateWhereDlWasIssued = "FL", // Florida
                },
                new Person
                {
                    id = 6,
                    PersonTypeId = 55, // Mentee
                    PrefixId = 3, // Ms
                    FirstName = "Jane",
                    MiddleInitial = "",
                    LastName = "Doe",
                    SuffixId = 0, // None
                    DOB = DateTime.Parse("05/05/1969"),
                    MisdemeanorArrested = 0,
                    MisdemeanorConvicted = 0,
                    FelonyArrested = 1,
                    FelonyConvicted = 1,
                    RaceId = 20, // White
                    GenderId = 16, // Female
                    SSN = "666-66-6666",
                    StateDl = "D666-666-66-666-6",
                    StateWhereDlWasIssued = "FL", // Florida
                },
                new Person
                {
                    id = 7,
                    PersonTypeId = 51, // Lead Mentor
                    PrefixId = 4, // Dr
                    FirstName = "Sam",
                    MiddleInitial = "",
                    LastName = "Dobson",
                    SuffixId = 12, // PhD
                    DOB = DateTime.Parse("05/05/1969"),
                    MisdemeanorArrested = 0,
                    MisdemeanorConvicted = 0,
                    FelonyArrested = 0,
                    FelonyConvicted = 0,
                    RaceId = 20, // white
                    GenderId = 15, // male
                    SSN = "777-77-7777",
                    StateDl = "D777-777-77-777-7",
                    StateWhereDlWasIssued = "FL", // Florida
                },
                new Person
                {
                    id = 8,
                    PersonTypeId = 51, // Lead Mentor
                    PrefixId = 4, // Dr
                    FirstName = "Walt",
                    MiddleInitial = "",
                    LastName = "Disney",
                    SuffixId = 0, // none
                    DOB = DateTime.Parse("05/05/1969"),
                    MisdemeanorArrested = 0,
                    MisdemeanorConvicted = 0,
                    FelonyArrested = 0,
                    FelonyConvicted = 0,
                    RaceId = 20, // white
                    GenderId = 15, // male
                    SSN = "888-88-8888",
                    StateDl = "D888-888-88-888-8",
                    StateWhereDlWasIssued = "FL", // Florida
                },
            };

            return people;
        }

        private static List<Address> GetAddresses()
        {
            var addrs = new List<Address>
            {
                new Address
                {
                    id = 1,
                    StateCode = "FL",
                    Street1 = "1234 Anywhere Street",
                    Street2 = "Apt. 2B",
                    CityId = 13102, // Jacksonville
                    PostalCode5 = 32205
                },
                new Address
                {
                    id = 2,
                    StateCode = "FL",
                    Street1 = "515 Main Street",
                    CityId = 13102, // Jacksonville
                    PostalCode5 = 32205
                },
                new Address
                {
                    id = 3,
                    StateCode = "FL",
                    Street1 = "1 UNF Drive",
                    CityId = 13102, // Jacksonville
                    PostalCode5 = 32224
                },
                new Address
                {
                    id = 4,
                    StateCode = "FL",
                    Street1 = "2868 Rockford Falls Drive N",
                    CityId = 13102, // Jacksonville
                    PostalCode5 = 32224
                },
                new Address
                {
                    id = 5,
                    StateCode = "FL",
                    Street1 = "22 West Abbleton Live Street",
                    CityId = 13102, // Jacksonville
                    PostalCode5 = 32204
                },
                new Address
                {
                    id = 6,
                    StateCode = "FL",
                    Street1 = "22 West Abbleton Live Street",
                    CityId = 13102, // Jacksonville
                    PostalCode5 = 32204
                },
            };

            return addrs;
        }

        private static List<PersonAddress> GetAddressXRef()
        {
            var xref = new List<PersonAddress>
            {
                new PersonAddress
                {
                    id = 1,
                    AddressId = 1,
                    PersonId = 1,
                    AddressType = 65, // Home
                },
                new PersonAddress
                {
                    id = 2,
                    AddressId = 2,
                    PersonId = 2,
                    AddressType = 65, // Home
                },
                new PersonAddress
                {
                    id = 3,
                    AddressId = 3,
                    PersonId = 1,
                    AddressType = 66, // Work
                },
            };

            return xref;
        }

        private static List<MentorApplication> GetApplications()
        {
            var apps = new List<MentorApplication>
            {
                new MentorApplication
                {
                    id = 1,
                    PersonId = 2, // Bob Roggio
                    MinistryId = 1, // Jacksonville Baptist Church
                    RegistrationDate = DateTime.Now,
                    AgreeToTerms = 1, // Yes, true
                    Availability = "Monday-Friday, 8AM to 5PM",
                    HasRelationIncarcerated = 0,
                    MinistryExperience = "10+ years as a counselor",
                    RelativesWorkingForDoC = 0,
                    SpecialHobbies = "A good talker",
                    SpecialRequests = "None",
                },
                new MentorApplication
                {
                    id = 2,
                    PersonId = 4, // Cassedy Conant
                    MinistryId = 1, // Jacksonville Baptist Church
                    RegistrationDate = DateTime.Now,
                    AgreeToTerms = 1, // Yes, true
                    Availability = "Monday-Saturday, 12PM to 8PM",
                    HasRelationIncarcerated = 0,
                    MinistryExperience = "3+ years as a mentor",
                    RelativesWorkingForDoC = 0,
                    SpecialHobbies = "Good at computer skills",
                    SpecialRequests = "None"
                },
                new MentorApplication
                {
                    id = 3,
                    PersonId = 7, // Sam Dobson
                    MinistryId = 2, // Jacksonville Baptist Church
                    RegistrationDate = DateTime.Now,
                    AgreeToTerms = 1, // Yes, true
                    Availability = "Mon, Wed, Fri 7AM to 12PM",
                    HasRelationIncarcerated = 0,
                    MinistryExperience = "20 years as a mentor",
                    RelativesWorkingForDoC = 0,
                    SpecialHobbies = "Been doing this for a long time",
                    SpecialRequests = "None"
                },
                new MentorApplication
                {
                    id = 4,
                    PersonId = 1, // David King (admin)
                    MinistryId = 1, // Jacksonville Baptist Church
                    RegistrationDate = DateTime.Now,
                    AgreeToTerms = 1, // Yes, true
                    Availability = "Monday-Friday, 8AM to 5PM",
                    HasRelationIncarcerated = 0,
                    MinistryExperience = "10+ years as a counselor",
                    RelativesWorkingForDoC = 0,
                    SpecialHobbies = "A good talker",
                    SpecialRequests = "None",
                },
            };

            return apps;
        }

        private static List<Ministry> GetMinistries()
        {
            var ministries = new List<Ministry>
            {
                new Ministry
                {
                    id = 1,
                    MinistryName = "Jacksonville Baptist Church",
                    LeadMentorId = 7,
                    Description = "Jacksonville Baptist Church"
                },
                new Ministry
                {
                    id = 2,
                    MinistryName = "First Presbyterian Church",
                    LeadMentorId = 8,
                    Description = "First Presbyterian Church of Jacksonville, FL"
                }
            };

            return ministries;
        }


        private static List<UserInRole> GetUsersInRoles()
        {
            var UIRs = new List<UserInRole>
            {
                new UserInRole
                {
                    UserId = 1, // Administrator User
                    RoleId = 1, // Administrator Role
                    CreatedOn = DateTime.Now
                },
                new UserInRole
                {
                    UserId = 1, // Administrator User
                    RoleId = 2, // JREC Staff Role
                    CreatedOn = DateTime.Now
                },
                new UserInRole
                {
                    UserId = 2, // Mentor User
                    RoleId = 5, // Mentor Role
                    CreatedOn = DateTime.Now
                },
                new UserInRole
                {
                    UserId = 3, // Chaplain User
                    RoleId = 7, // Chaplain Role
                    CreatedOn = DateTime.Now
                }
            };

            return UIRs;
        }

        private static List<State> GetStates()
        {
            var states = new List<State>
						 {
							 new State { id = 1, Name = "Alaska",                StateCode = "AK" },
							 new State { id = 2, Name = "Alabama",               StateCode = "AL" },
							 new State { id = 3, Name = "Arkansas",              StateCode = "AR" },
							 new State { id = 4, Name = "Arizona",               StateCode = "AZ" },
							 new State { id = 5, Name = "California",            StateCode = "CA" },
							 new State { id = 6, Name = "Colorado",              StateCode = "CO" },
							 new State { id = 7, Name = "Connecticut",           StateCode = "CT" },
							 new State { id = 8, Name = "District of Columbia",  StateCode = "DC" },
							 new State { id = 9, Name = "Delaware",              StateCode = "DE" },
							 new State { id = 10, Name = "Florida",              StateCode = "FL" },
							 new State { id = 11, Name = "Georgia",              StateCode = "GA" },
							 new State { id = 12, Name = "Hawaii",               StateCode = "HI" },
							 new State { id = 13, Name = "Iowa",                 StateCode = "IA" },
							 new State { id = 14, Name = "Idaho",                StateCode = "ID" },
							 new State { id = 15, Name = "Illinois",             StateCode = "IL" },
							 new State { id = 16, Name = "Indiana",              StateCode = "IN" },
							 new State { id = 17, Name = "Kansas",               StateCode = "KS" },
							 new State { id = 18, Name = "Kentucky",             StateCode = "KY" },
							 new State { id = 19, Name = "Louisiana",            StateCode = "LA" },
							 new State { id = 20, Name = "Massachusetts",        StateCode = "MA" },
							 new State { id = 21, Name = "Maryland",             StateCode = "MD" },
							 new State { id = 22, Name = "Maine",                StateCode = "ME" },
							 new State { id = 23, Name = "Michigan",             StateCode = "MI" },
							 new State { id = 24, Name = "Minnesota",            StateCode = "MN" },
							 new State { id = 25, Name = "Missouri",             StateCode = "MO" },
							 new State { id = 26, Name = "Mississippi",          StateCode = "MS" },
							 new State { id = 27, Name = "Montana",              StateCode = "MT" },
							 new State { id = 28, Name = "North Carolina",       StateCode = "NC" },
							 new State { id = 29, Name = "North Dakota",         StateCode = "ND" },
							 new State { id = 30, Name = "Nebraska",             StateCode = "NE" },
							 new State { id = 31, Name = "New Hampshire",        StateCode = "NH" },
							 new State { id = 32, Name = "New Jersey",           StateCode = "NJ" },
							 new State { id = 33, Name = "New Mexico",           StateCode = "NM" },
							 new State { id = 34, Name = "Nevada",               StateCode = "NV" },
							 new State { id = 35, Name = "New York",             StateCode = "NY" },
							 new State { id = 36, Name = "Ohio",                 StateCode = "OH" },
							 new State { id = 37, Name = "Oklahoma",             StateCode = "OK" },
							 new State { id = 38, Name = "Oregon",               StateCode = "OR" },
							 new State { id = 39, Name = "Pennsylvania",         StateCode = "PA" },
							 new State { id = 40, Name = "Rhode Island",         StateCode = "RI" },
							 new State { id = 41, Name = "South Carolina",       StateCode = "SC" },
							 new State { id = 42, Name = "Tennessee",            StateCode = "TN" },
							 new State { id = 43, Name = "Texas",                StateCode = "TX" },
							 new State { id = 44, Name = "Utah",                 StateCode = "UT" },
							 new State { id = 45, Name = "Virginia",             StateCode = "VA" },
							 new State { id = 46, Name = "Vermont",              StateCode = "VT" },
							 new State { id = 47, Name = "Washington",           StateCode = "WA" },
							 new State { id = 48, Name = "Wisconsin",            StateCode = "WI" },
							 new State { id = 49, Name = "West Virginia",        StateCode = "WV" },
							 new State { id = 50, Name = "Wyoming",              StateCode = "WY" }
						 };

            return states;
        }

        private static List<CalendarEvent> GetEvents()
        {
            var events = new List<CalendarEvent>
            {
                new CalendarEvent
                {
                    id = 1,
                    EventBegins = DateTime.Now,
                    EventEnds = DateTime.Now.AddHours(2),
                    EventName = "Test Event",
                    EventDetails = "This is a test event",
                    EventType = 25,
                    AllDayEvent = 0
                }
            };

            return events;
        }

        private static List<Message> GetMessages()
        {
            var msgs = new List<Message>
			{
				new Message 
                {
                    id = 0,
                    FromUserId = 2,
                    ToUserId = 1,
                    Created = DateTime.Today,
                    IsFlashTraffic = false,
                    Subject = "Test Message",
                    Body = "This is just a test message to see if the system can retrieve data"
                }
            };

            return msgs;
        }
    }
}
