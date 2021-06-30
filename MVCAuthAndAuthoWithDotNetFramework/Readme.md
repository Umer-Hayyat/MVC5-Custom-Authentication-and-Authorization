Followed: https://www.compose.com/articles/code-first-database-design-with-entity-framework-and-postgresql/


#Migrations
	Followed: 
		https://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx

	To enable migrations
		enable-migrations

	To add a migration
		Add-Migration RenamedUserCSToUSerDBModelCS

	To apply specific migration (Note: -force will delete the data in the database)
		update-database -TargetMigration RenamedUserCSToUSerDBModelCS -force
	

#Todo
	Currently, migrations are being applied on model rather dbModel. need to fix this


#SomeTips
	IF you dont wnat to cache a query, call AsNoTracking() on relevent context first i.e
		DbContext.Users.AsNoTracking().First(x => x.ID == userID)
	
	Dont use a common/classlevel dbcontext as it will cause multiple issues i.e
		if you want to modifiy any entity in a way that in the single go you first retrieve it from database, after changing attributes of entity
		you want to save those changes in the database, it will give you an error because entity framework is tracking that entity

	Use using() block to avaoid above stated scenarios

#MVC

	RedirectToRoute:
		https://stackoverflow.com/questions/8944355/redirecttoaction-and-redirecttoroute

#C#
	c# func vs normal method 
		Google search: https://www.google.com/search?q=c%23+func+vs+normal+method&rlz=1C1SQJL_enPK901PK901&oq=c%23+func+vs+normal+method&aqs=chrome..69i57j69i58.6423j0j4&sourceid=chrome&ie=UTF-8
		Stackoverflow: https://stackoverflow.com/questions/7630538/action-func-vs-methods-whats-the-point#:~:text=2)%20Methods%20can%20have%20overloads,name%20in%20a%20given%20scope.&text=6)%20Methods%20can%20have%20optional%20parameters%2C%20not%20Action%20%2F%20Func%20.
		