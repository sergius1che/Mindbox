SELECT
  p.name AS product_name,
  c.name AS category_name
FROM products p
  LEFT JOIN product_categories pc ON pc.product_id = p.id
  LEFT JOIN categories c ON c.id = pc.category_id