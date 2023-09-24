Use [RandomUSD]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Material_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Insert a new Material
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Material_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Material_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Material_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Material_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Material_Insert >>>'

    End

GO

Create PROCEDURE Material_Insert

    -- Add the parameters for the stored procedure here
    @MaterialType int,
    @Path nvarchar(128),
    @Text nvarchar(max),
    @Title nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Material]
    ([MaterialType],[Path],[Text],[Title])

    -- Begin Values List
    Values(@MaterialType, @Path, @Text, @Title)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Material_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Update an existing Material
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Material_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Material_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Material_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Material_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Material_Update >>>'

    End

GO

Create PROCEDURE Material_Update

    -- Add the parameters for the stored procedure here
    @Id int,
    @MaterialType int,
    @Path nvarchar(128),
    @Text nvarchar(max),
    @Title nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Material]

    -- Update Each field
    Set [MaterialType] = @MaterialType,
    [Path] = @Path,
    [Text] = @Text,
    [Title] = @Title

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Material_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Find an existing Material
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Material_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Material_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Material_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Material_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Material_Find >>>'

    End

GO

Create PROCEDURE Material_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[MaterialType],[Path],[Text],[Title]

    -- From tableName
    From [Material]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Material_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Delete an existing Material
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Material_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Material_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Material_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Material_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Material_Delete >>>'

    End

GO

Create PROCEDURE Material_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Material]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Material_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Returns all Material objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Material_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Material_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Material_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Material_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Material_FetchAll >>>'

    End

GO

Create PROCEDURE Material_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[MaterialType],[Path],[Text],[Title]

    -- From tableName
    From [Material]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Prop_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Insert a new Prop
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Prop_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Prop_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Prop_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Prop_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Prop_Insert >>>'

    End

GO

Create PROCEDURE Prop_Insert

    -- Add the parameters for the stored procedure here
    @CreateText nvarchar(512),
    @Name nvarchar(50),
    @TransformText nvarchar(512)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Prop]
    ([CreateText],[Name],[TransformText])

    -- Begin Values List
    Values(@CreateText, @Name, @TransformText)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Prop_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Update an existing Prop
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Prop_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Prop_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Prop_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Prop_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Prop_Update >>>'

    End

GO

Create PROCEDURE Prop_Update

    -- Add the parameters for the stored procedure here
    @CreateText nvarchar(512),
    @Id int,
    @Name nvarchar(50),
    @TransformText nvarchar(512)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Prop]

    -- Update Each field
    Set [CreateText] = @CreateText,
    [Name] = @Name,
    [TransformText] = @TransformText

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Prop_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Find an existing Prop
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Prop_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Prop_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Prop_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Prop_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Prop_Find >>>'

    End

GO

Create PROCEDURE Prop_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreateText],[Id],[Name],[TransformText]

    -- From tableName
    From [Prop]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Prop_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Delete an existing Prop
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Prop_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Prop_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Prop_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Prop_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Prop_Delete >>>'

    End

GO

Create PROCEDURE Prop_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Prop]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Prop_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Returns all Prop objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Prop_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Prop_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Prop_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Prop_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Prop_FetchAll >>>'

    End

GO

Create PROCEDURE Prop_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreateText],[Id],[Name],[TransformText]

    -- From tableName
    From [Prop]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Scene_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Insert a new Scene
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Scene_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Scene_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Scene_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Scene_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Scene_Insert >>>'

    End

GO

Create PROCEDURE Scene_Insert

    -- Add the parameters for the stored procedure here
    @Name nvarchar(50),
    @Text nvarchar(max)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Scene]
    ([Name],[Text])

    -- Begin Values List
    Values(@Name, @Text)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Scene_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Update an existing Scene
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Scene_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Scene_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Scene_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Scene_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Scene_Update >>>'

    End

GO

Create PROCEDURE Scene_Update

    -- Add the parameters for the stored procedure here
    @Id int,
    @Name nvarchar(50),
    @Text nvarchar(max)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Scene]

    -- Update Each field
    Set [Name] = @Name,
    [Text] = @Text

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Scene_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Find an existing Scene
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Scene_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Scene_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Scene_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Scene_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Scene_Find >>>'

    End

GO

Create PROCEDURE Scene_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[Name],[Text]

    -- From tableName
    From [Scene]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Scene_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Delete an existing Scene
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Scene_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Scene_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Scene_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Scene_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Scene_Delete >>>'

    End

GO

Create PROCEDURE Scene_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Scene]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Scene_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/16/2023
-- Description:    Returns all Scene objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Scene_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Scene_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Scene_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Scene_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Scene_FetchAll >>>'

    End

GO

Create PROCEDURE Scene_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[Name],[Text]

    -- From tableName
    From [Scene]

END

-- Thank you for using DataTier.Net.

