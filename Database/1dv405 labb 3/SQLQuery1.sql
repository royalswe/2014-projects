SELECT        TOP (100) PERCENT dbo.Artikel.ArtikelID, dbo.Artikel.Artnamn, dbo.Fakturarad.Antal, dbo.Fakturarad.Pris, dbo.Fakturarad.Rabatt * 100 AS [Rabatt i %], dbo.Moms.Moms * 100 AS [Moms i %], 
                         CONVERT(DECIMAL(10,2),(((dbo.Fakturarad.Antal * dbo.Fakturarad.Pris) * (1 - dbo.Fakturarad.Rabatt)) * (1 + dbo.Moms.Moms))) AS Summan
FROM            dbo.Faktura INNER JOIN
                         dbo.Fakturarad ON dbo.Faktura.FakturaID = dbo.Fakturarad.FakturaID INNER JOIN
                         dbo.Artikel ON dbo.Fakturarad.ArtikelID = dbo.Artikel.ArtikelID INNER JOIN
                         dbo.Moms ON dbo.Fakturarad.MomsID = dbo.Moms.MomsID
ORDER BY dbo.Faktura.Datum