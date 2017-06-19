/************************************************************
 * Code  by ����  ��һ�γ�ʼ�� д��
 * Time: 2017/5/31
 * Code  by ����  ��һ���޸� �����н�� ����1000�� ��ֹ����̫�� ����ҳ����ʾ����
 * Time: 2017/5/31
 ************************************************************/
 GO
CREATE PROC Sys_Job_Order_Proc
AS 
BEGIN
	DELETE FROM OrderReport
	INSERT INTO OrderReport
	SELECT 
		   NEWID(),
	       o.UnitId              AS UnitId,
	       o.UserId,
	       c.Id                  AS CategoryId,
	       b.Id                  AS BrandId,
	       o.SourcesId,
	       Convert(decimal(18,2),SUM(o.ActualAmount)/1000)   AS ActualAmount,
	       CONVERT(VARCHAR(100), o.OrderDate, 23) AS OrderDate,
	       o.PayMethod
	FROM   OrdersDetail          AS od
	       INNER JOIN Orders     AS o  ON  od.OrderId = o.Id
	       INNER JOIN ItemPrice  AS ip ON  ip.Id = od.PriceId
	       INNER JOIN Item       AS i  ON  i.Id = ip.ItemId
	       INNER JOIN Brand      AS b  ON  b.Id = i.BrandId
	       INNER JOIN Category   AS c  ON  c.Id = i.CategoryId
	GROUP BY o.UnitId,  c.Id, b.Id, CONVERT(VARCHAR(100), o.OrderDate, 23), o.SourcesId, o.UserId, o.PayMethod
	ORDER BY CONVERT(VARCHAR(100), o.OrderDate, 23) DESC
END 
