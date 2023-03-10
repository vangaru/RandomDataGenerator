CREATE PROCEDURE GetStats
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
		SUM(CAST(IntegerNumber AS BIGINT)) AS 'IntSum',
		(SELECT TOP(1) PERCENTILE_DISC(0.5) WITHIN GROUP (ORDER BY FloatingNumber) OVER() FROM FileEntries) AS 'FloatMedian'
	FROM FileEntries
END