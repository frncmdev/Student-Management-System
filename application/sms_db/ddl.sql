CREATE TABLE [dbo].[unitCourseAllocation] (
    [UCAID]      INT           IDENTITY (1000, 1) NOT NULL,
    [CourseCode] NVARCHAR (50) NOT NULL,
    [UnitCode]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UCAID] ASC),
    CONSTRAINT [FK_Course_UCA] FOREIGN KEY ([CourseCode]) REFERENCES [dbo].[course] ([courseCode]),
    CONSTRAINT [FK_Unit_UCA] FOREIGN KEY ([UnitCode]) REFERENCES [dbo].[unit] ([UnitCode])
);


GO

CREATE TABLE [dbo].[unit] (
    [UnitCode]  NVARCHAR (50)  NOT NULL,
    [UnitName]  NVARCHAR (100) NOT NULL,
    [teacherID] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([UnitCode] ASC),
    CONSTRAINT [FK_Teacher_unit] FOREIGN KEY ([teacherID]) REFERENCES [dbo].[Teacher] ([TeacherID])
);


GO

CREATE TABLE [dbo].[student] (
    [studentID]   INT            IDENTITY (1000000, 1) NOT NULL,
    [fullname]    NVARCHAR (150) NOT NULL,
    [dateofbirth] DATE           NOT NULL,
    [dateCreated] DATE           NOT NULL,
    [email]       NVARCHAR (250) NOT NULL,
    [PASSWORD]    NVARCHAR (MAX) NOT NULL,
    [salt]        NVARCHAR (16)  NOT NULL,
    [pictureURL]  NVARCHAR (MAX) NULL,
    [citizenOf]   NVARCHAR (60)  NULL,
    [schoolID]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([studentID] ASC),
    CONSTRAINT [FK_School_Student] FOREIGN KEY ([schoolID]) REFERENCES [dbo].[School] ([SchoolID])
);


GO

CREATE TABLE [dbo].[School] (
    [SchoolID]   INT            IDENTITY (1, 1) NOT NULL,
    [SchoolName] NVARCHAR (100) NULL,
    [SchoolURL]  NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([SchoolID] ASC)
);


GO

CREATE TABLE [dbo].[enrollment] (
    [enrollmentID] NVARCHAR (32) NOT NULL,
    [year]         INT           NOT NULL,
    [semester]     INT           NOT NULL,
    [UnitCode]     NVARCHAR (50) NOT NULL,
    [studentID]    INT           NOT NULL,
    [GradeID]      NVARCHAR (12) NOT NULL,
    PRIMARY KEY CLUSTERED ([enrollmentID] ASC),
    CONSTRAINT [FK_Student_Enrollment] FOREIGN KEY ([studentID]) REFERENCES [dbo].[student] ([studentID]),
    CONSTRAINT [FK_Unit_Enrollment] FOREIGN KEY ([UnitCode]) REFERENCES [dbo].[unit] ([UnitCode]),
    CONSTRAINT [FK_Unit_Grade] FOREIGN KEY ([GradeID]) REFERENCES [dbo].[GradeType] ([GradeID])
);


GO

CREATE TABLE [dbo].[courseType] (
    [CourseTypeID]   INT            NOT NULL,
    [CourseTypeDesc] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([CourseTypeID] ASC)
);


GO

CREATE TABLE [dbo].[GradeType] (
    [GradeID]   NVARCHAR (12) NOT NULL,
    [GradeDesc] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([GradeID] ASC)
);


GO

CREATE TABLE [dbo].[Teacher] (
    [TeacherID]   NVARCHAR (100) NOT NULL,
    [fullname]    NVARCHAR (150) NOT NULL,
    [dateofbirth] DATE           NOT NULL,
    [dateCreated] DATE           NOT NULL,
    [email]       NVARCHAR (250) NOT NULL,
    [PASSWORD]    NVARCHAR (MAX) NOT NULL,
    [salt]        NVARCHAR (16)  NOT NULL,
    [pictureURL]  NVARCHAR (MAX) NULL,
    [schoolID]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([TeacherID] ASC),
    CONSTRAINT [FK_School_Teacher] FOREIGN KEY ([schoolID]) REFERENCES [dbo].[School] ([SchoolID])
);


GO

CREATE TABLE [dbo].[course] (
    [courseCode]   NVARCHAR (50)  NOT NULL,
    [courseName]   NVARCHAR (100) NULL,
    [CourseTypeID] INT            NOT NULL,
    [schoolID]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([courseCode] ASC),
    CONSTRAINT [FK_CourseType_Course] FOREIGN KEY ([CourseTypeID]) REFERENCES [dbo].[courseType] ([CourseTypeID]),
    CONSTRAINT [FK_School_Course] FOREIGN KEY ([schoolID]) REFERENCES [dbo].[School] ([SchoolID])
);


GO

