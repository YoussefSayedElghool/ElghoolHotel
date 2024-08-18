# Initium Solutions Assessment Assignment
## ElghoolHotel

### Demo 
https://github.com/user-attachments/assets/4b686d28-d32f-40e8-92e1-d3b4d8fe0892


To include the database schema in a README file, here’s how you can structure the tables for better readability:

---

### Database Tables

#### 1. `__EFMigrationsHistory`

| Column Name     | Data Type   | Constraints |
|-----------------|-------------|-------------|
| `MigrationId`   | nvarchar(150) | NOT NULL PRIMARY KEY |
| `ProductVersion`| nvarchar(32)  | NOT NULL |

#### 2. `AspNetRoleClaims`

| Column Name   | Data Type      | Constraints |
|---------------|----------------|-------------|
| `Id`          | int            | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `RoleId`      | nvarchar(450)  | NOT NULL |
| `ClaimType`   | nvarchar(max)  | NULL |
| `ClaimValue`  | nvarchar(max)  | NULL |

#### 3. `AspNetRoles`

| Column Name        | Data Type      | Constraints |
|--------------------|----------------|-------------|
| `Id`               | nvarchar(450)  | NOT NULL PRIMARY KEY |
| `Name`             | nvarchar(256)  | NULL |
| `NormalizedName`   | nvarchar(256)  | NULL |
| `ConcurrencyStamp` | nvarchar(max)  | NULL |

#### 4. `AspNetUserClaims`

| Column Name   | Data Type      | Constraints |
|---------------|----------------|-------------|
| `Id`          | int            | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `UserId`      | nvarchar(450)  | NOT NULL |
| `ClaimType`   | nvarchar(max)  | NULL |
| `ClaimValue`  | nvarchar(max)  | NULL |

#### 5. `AspNetUserLogins`

| Column Name          | Data Type      | Constraints |
|----------------------|----------------|-------------|
| `LoginProvider`      | nvarchar(450)  | NOT NULL PRIMARY KEY |
| `ProviderKey`        | nvarchar(450)  | NOT NULL PRIMARY KEY |
| `ProviderDisplayName`| nvarchar(max)  | NULL |
| `UserId`             | nvarchar(450)  | NOT NULL |

#### 6. `AspNetUserRoles`

| Column Name | Data Type      | Constraints |
|-------------|----------------|-------------|
| `UserId`    | nvarchar(450)  | NOT NULL PRIMARY KEY |
| `RoleId`    | nvarchar(450)  | NOT NULL PRIMARY KEY |

#### 7. `AspNetUsers`

| Column Name            | Data Type       | Constraints |
|------------------------|-----------------|-------------|
| `Id`                   | nvarchar(450)   | NOT NULL PRIMARY KEY |
| `DisplayName`          | nvarchar(max)   | NOT NULL |
| `Image`                | nvarchar(max)   | NOT NULL |
| `UserName`             | nvarchar(256)   | NULL |
| `NormalizedUserName`   | nvarchar(256)   | NULL |
| `Email`                | nvarchar(256)   | NULL |
| `NormalizedEmail`      | nvarchar(256)   | NULL |
| `EmailConfirmed`       | bit             | NOT NULL |
| `PasswordHash`         | nvarchar(max)   | NULL |
| `Discount`             | float           | NOT NULL |
| `HasDiscount`          | bit             | NOT NULL |
| `NationalId`           | nvarchar(max)   | NOT NULL |

#### 8. `AspNetUserTokens`

| Column Name   | Data Type      | Constraints |
|---------------|----------------|-------------|
| `UserId`      | nvarchar(450)  | NOT NULL PRIMARY KEY |
| `LoginProvider`| nvarchar(450) | NOT NULL PRIMARY KEY |
| `Name`        | nvarchar(450)  | NOT NULL PRIMARY KEY |
| `Value`       | nvarchar(max)  | NULL |


#### 9. `Bookings`

| Column Name  | Data Type       | Constraints |
|--------------|-----------------|-------------|
| `BookingId`  | int             | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `CheckInDate`| datetime2(7)    | NOT NULL |
| `CheckOutDate`| datetime2(7)   | NOT NULL |
| `UserId`     | nvarchar(450)   | NOT NULL |

#### 10. `Cities`

| Column Name | Data Type    | Constraints |
|-------------|--------------|-------------|
| `CityId`    | int          | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `Name`      | nvarchar(max)| NOT NULL |

#### 11. `Hotels`

| Column Name | Data Type    | Constraints |
|-------------|--------------|-------------|
| `HotelId`   | int          | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `Name`      | nvarchar(max)| NOT NULL |
| `CityId`    | int          | NOT NULL |

#### 12. `RefreshTokens`

| Column Name  | Data Type       | Constraints |
|--------------|-----------------|-------------|
| `RefreshTokenId` | int         | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `Token`          | nvarchar(max)| NOT NULL |
| `ExpiresOn`      | datetime2(7) | NOT NULL |
| `CreatedOn`      | datetime2(7) | NOT NULL |
| `RevokedOn`      | datetime2(7) | NULL |
| `UserId`         | nvarchar(450)| NOT NULL |

#### 15. `Reviews`

| Column Name  | Data Type      | Constraints |
|--------------|----------------|-------------|
| `ReviewId`   | int            | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `UserImageUrl`| nvarchar(max) | NOT NULL |
| `UserReview` | nvarchar(max)  | NOT NULL |

#### 16. `RoomRequests`

| Column Name     | Data Type | Constraints |
|-----------------|-----------|-------------|
| `RoomRequestId` | int       | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `AdultNumber`   | int       | NOT NULL |
| `ChildrenNumber`| int       | NOT NULL |
| `HotelId`       | int       | NOT NULL |
| `RoomTypeId`    | int       | NOT NULL |
| `BookingId`     | int       | NOT NULL |

#### 17. `Rooms`

| Column Name       | Data Type    | Constraints |
|-------------------|--------------|-------------|
| `RoomId`          | int          | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `Name`            | nvarchar(max)| NOT NULL |
| `MaxAdultNumber`  | int          | NOT NULL |
| `MaxChildrenNumber`| int         | NOT NULL |
| `Price`           | float        | NOT NULL |
| `HotelId`         | int          | NOT NULL |
| `RoomTypeId`      | int          | NOT NULL |

#### 18. `RoomTypes`

| Column Name   | Data Type    | Constraints |
|---------------|--------------|-------------|
| `RoomTypeId`  | int          | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `Type`        | nvarchar(max)| NOT NULL |

#### 19. `Sliders`

| Column Name | Data Type    | Constraints |
|-------------|--------------|-------------|
| `SliderId`  | int          | IDENTITY(1,1) NOT NULL PRIMARY KEY |
| `ImageUrl`  | nvarchar(max)| NOT NULL |

