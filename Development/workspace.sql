USE [AppleStructure]
GO

select * from [Hierarchy];

SELECT 
	*
FROM 
	[dbo].[V_ContentWithHierachy]

select * from [Content];

WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Parent IS NULL AND HRoot.Id = 1
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT HierarchyCTE.Id, HierarchyCTE.LEVEL
FROM HierarchyCTE
LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
ORDER BY LEVEL DESC;

WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Parent IS NULL AND HRoot.Id = 2
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT 'yes' AS isExists WHERE  EXISTS ( SELECT null FROM HierarchyCTE
LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
WHERE C.Id IS NOT NULL  )  
;


WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Parent IS NULL AND HRoot.Id = 15
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT 'yes' AS isExists WHERE  EXISTS ( SELECT null FROM HierarchyCTE
LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
WHERE C.Id IS NOT NULL  )

WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Parent IS NULL AND HRoot.Id = 15
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT * from HierarchyCTE LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
;

WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = 15
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT * from HierarchyCTE LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
;

WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = 15
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT DISTINCT HierarchyCTE.Id AS C_ID, HierarchyCTE.LEVEL
FROM HierarchyCTE
LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
ORDER BY LEVEL DESC


WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = 7
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT 'yes' AS isExists WHERE  EXISTS ( SELECT null FROM HierarchyCTE
LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
WHERE C.Id IS NOT NULL  )

WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = 1
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT DISTINCT HierarchyCTE.Id AS ID, HierarchyCTE.LEVEL
FROM HierarchyCTE
LEFT JOIN [Content] C ON HierarchyCTE.Id = C.Hierarchy
EXCEPT
SELECT HRoot.Id, 1
FROM Hierarchy HRoot
WHERE HRoot.Id = 1
ORDER BY LEVEL DESC

WITH HierarchyCTE (Id, Name, Parent, LEVEL)
AS (SELECT HRoot.Id, HRoot.Name, HRoot.Parent, 0
FROM Hierarchy HRoot
WHERE HRoot.Parent IS NULL
UNION ALL
SELECT HChild.Id, HChild.Name, HChild.Parent, CTE.LEVEL + 1 
FROM Hierarchy HChild
INNER JOIN HierarchyCTE CTE ON HChild.Parent = CTE.Id
WHERE HChild.Parent IS NOT NULL)
SELECT HierarchyCTE.Id AS ID, HierarchyCTE.Parent AS Parent , HierarchyCTE.Name AS Name,LEVEL
FROM HierarchyCTE
ORDER BY HierarchyCTE.LEVEL