/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

EXEC SP_User_insert 'admin@test.be','Test1234='
GO

DECLARE @admin_id UNIQUEIDENTIFIER
SET @admin_id=(SELECT TOP(1) [User_Id] FROM [User])
EXEC SP_Admin_Toggle @admin_id 
GO