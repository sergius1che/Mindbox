CREATE TABLE public.products (
  id SERIAL NOT NULL,
  name VARCHAR(256),
  PRIMARY KEY(id)
) 
WITH (oids = false);

CREATE TABLE public.categories (
  id SERIAL NOT NULL,
  name VARCHAR(256),
  PRIMARY KEY(id)
) 
WITH (oids = false);

CREATE TABLE public.product_categories (
  id SERIAL,
  product_id BIGINT NOT NULL,
  category_id BIGINT NOT NULL,
  CONSTRAINT product_categories_pkey PRIMARY KEY(id),
  CONSTRAINT product_categories_product_fk FOREIGN KEY (product_id)
    REFERENCES public.products(id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT product_categories_category_fk FOREIGN KEY (category_id)
    REFERENCES public.categories(id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);