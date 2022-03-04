SELECT pos.no, vrac_no, description, item_family, scientific_description, bio, cosmetic, price_incl_tax, density, pao, ingredients,  lot, origin, dlu, rd.precautions_etiquette, rd.mode_emploi
FROM dbo.products pro LEFT JOIN dbo.pos_vrac pos ON (pro.no = pos.no)
                      LEFT JOIN dbo.app_rd_dip rd ON (pos.rd_no = rd.no)
						LEFT JOIN (
									SELECT SKU, pos.lot, slot, origin, dlu, device, pos.pos, scan_date
			     					FROM dbo.pos_vrac_support pos 
			     					JOIN dbo.erp_vrac_support erp ON (pos.vrac_no = erp.SKU) AND pos.lot = erp.lot AND pos.slot = erp.slo
									JOIN (
      										SELECT last.pos, last.vrac_no, MAX(id) AS maxid
                                        	FROM dbo.pos_vrac_support AS last
                                        	GROUP BY  last.pos, last.vrac_no
										) AS req 
									ON (pos.pos = req.pos) AND pos.vrac_no = req.vrac_no AND pos.id = req.maxid
									WHERE pos.device = '" + @[User::device] +"'
									) AS maj 
						ON (pro.no = maj.SKU)
						WHERE pro.no LIKE '%V' 
						ORDER by vrac_no;




SELECT DISTINCT ip, device
FROM  pos_vrac_devices
WHERE  (pos = ?)
ORDER BY device, ip;


SELECT DISTINCT pos 
FROM dbo.pos_vrac_support

