namespace MMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mms1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Config",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        Value = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Key, t.Value });
            
            CreateTable(
                "dbo.Domain",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MiscData",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Key1 = c.String(),
                        Key2 = c.String(),
                        Key3 = c.String(),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        PersonId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CanBeDeleted = c.Boolean(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserInRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserRole", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        IsFlashTraffic = c.Boolean(nullable: false),
                        FromUserId = c.Int(nullable: false),
                        ToUserId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Subject = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ContactLog",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MentorId = c.Int(nullable: false),
                        MenteeId = c.Int(nullable: false),
                        ActivityTypeId = c.Int(nullable: false),
                        ContactTypeId = c.Int(nullable: false),
                        ContactDate = c.DateTime(nullable: false),
                        Details = c.String(),
                        Feedback = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        Location = c.String(),
                        RelativeUrl = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ministry",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MinistryName = c.String(),
                        AddressId = c.Int(nullable: false),
                        LeadMentorId = c.Int(nullable: false),
                        Description = c.String(),
                        MainPhoneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MaidenName = c.String(),
                        MiddleInitial = c.String(),
                        PrefixId = c.Int(nullable: false),
                        SuffixId = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        GenderId = c.Int(nullable: false),
                        SSN = c.String(),
                        RaceId = c.Int(nullable: false),
                        StateDl = c.String(),
                        StateWhereDlWasIssued = c.String(),
                        EmailAddress = c.String(),
                        FelonyArrested = c.Int(nullable: false),
                        FelonyConvicted = c.Int(nullable: false),
                        FelonyDescription = c.String(),
                        MisdemeanorArrested = c.Int(nullable: false),
                        MisdemeanorConvicted = c.Int(nullable: false),
                        MisdemeanorDescription = c.String(),
                        EmergencyContactName = c.String(),
                        StatusId = c.Int(nullable: false),
                        PersonTypeId = c.Int(nullable: false),
                        EmergencyContactPhone_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Phone", t => t.EmergencyContactPhone_id)
                .Index(t => t.EmergencyContactPhone_id);
            
            CreateTable(
                "dbo.Phone",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(),
                        AreaCode = c.String(),
                        PrefixCode = c.String(),
                        SuffixCode = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MentorMentee",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MentorPersonId = c.Int(nullable: false),
                        MenteePersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MentorMentor",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ParentPersonId = c.Int(nullable: false),
                        ChildPersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PersonPhones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        PhoneId = c.Int(nullable: false),
                        PhoneType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        CityId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        StateCode = c.String(),
                        PostalCode5 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PersonAddress",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        AddressType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CalendarEvent",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreatorId = c.Int(nullable: false),
                        EventName = c.String(),
                        AllDayEvent = c.Int(nullable: false),
                        EventBegins = c.DateTime(nullable: false),
                        EventEnds = c.DateTime(nullable: false),
                        EventUrl = c.String(),
                        EventDetails = c.String(),
                        SignupId = c.Int(nullable: false),
                        EventType = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        MentorId = c.Int(nullable: false),
                        MenteeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StateCode = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StateCode = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MentorApplication",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        AgreeToTerms = c.Int(nullable: false),
                        MinistryId = c.Int(nullable: false),
                        Availability = c.String(),
                        MinistryExperience = c.String(),
                        LeadershipSkills = c.String(),
                        SpecialHobbies = c.String(),
                        SpecialRequests = c.String(),
                        HasRelationIncarcerated = c.Int(nullable: false),
                        RelationIncarceratedName = c.String(),
                        RelationIncarceratedNumber = c.String(),
                        RelationIncarceratedType = c.String(),
                        WorkedForDoC = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(),
                        WhenWorkedStarted = c.DateTime(),
                        WhenWorkedEnded = c.DateTime(),
                        WhereDidYouWork = c.String(),
                        RelativesWorkingForDoC = c.Int(nullable: false),
                        RelativeWorkingForDoCName = c.String(),
                        RelativeWorkingForDoCRelationType = c.String(),
                        RelativeWorkingForDoCWorkLocation = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MentorAvailability",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MentorId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MentorReference",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MentorId = c.Int(nullable: false),
                        ReferrerId = c.Int(nullable: false),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Signee",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SignupId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.EventSignup",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        Minimum = c.Int(nullable: false),
                        Maximum = c.Int(nullable: false),
                        Opens = c.DateTime(nullable: false),
                        Closes = c.DateTime(nullable: false),
                        OpenToPublic = c.Boolean(nullable: false),
                        SignupIsOpen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Facility",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FacilityName = c.String(),
                        AddressId = c.Int(nullable: false),
                        PhoneId = c.Int(nullable: false),
                        ChaplainId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Person", new[] { "EmergencyContactPhone_id" });
            DropIndex("dbo.UserInRole", new[] { "RoleId" });
            DropIndex("dbo.UserInRole", new[] { "UserId" });
            DropForeignKey("dbo.Person", "EmergencyContactPhone_id", "dbo.Phone");
            DropForeignKey("dbo.UserInRole", "RoleId", "dbo.UserRole");
            DropForeignKey("dbo.UserInRole", "UserId", "dbo.UserProfile");
            DropTable("dbo.Facility");
            DropTable("dbo.EventSignup");
            DropTable("dbo.Signee");
            DropTable("dbo.MentorReference");
            DropTable("dbo.MentorAvailability");
            DropTable("dbo.MentorApplication");
            DropTable("dbo.City");
            DropTable("dbo.State");
            DropTable("dbo.CalendarEvent");
            DropTable("dbo.PersonAddress");
            DropTable("dbo.Address");
            DropTable("dbo.PersonPhones");
            DropTable("dbo.MentorMentor");
            DropTable("dbo.MentorMentee");
            DropTable("dbo.Phone");
            DropTable("dbo.Person");
            DropTable("dbo.Ministry");
            DropTable("dbo.Resource");
            DropTable("dbo.ContactLog");
            DropTable("dbo.Message");
            DropTable("dbo.UserInRole");
            DropTable("dbo.UserProfile");
            DropTable("dbo.UserRole");
            DropTable("dbo.MiscData");
            DropTable("dbo.Domain");
            DropTable("dbo.Config");
        }
    }
}
