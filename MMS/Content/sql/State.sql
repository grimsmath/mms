-- ---------------------------------
-- Table structure for State entity
-- ---------------------------------
DROP TABLE State;
CREATE TABLE State (
  Name varchar(22) NOT NULL,
  Code char(2) NOT NULL,
  PRIMARY KEY (Code)
)

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO State VALUES ('Alaska', 'AK');
INSERT INTO State VALUES ('Alabama', 'AL');
INSERT INTO State VALUES ('Arkansas', 'AR');
INSERT INTO State VALUES ('Arizona', 'AZ');
INSERT INTO State VALUES ('California', 'CA');
INSERT INTO State VALUES ('Colorado', 'CO');
INSERT INTO State VALUES ('Connecticut', 'CT');
INSERT INTO State VALUES ('District of Columbia', 'DC');
INSERT INTO State VALUES ('Delaware', 'DE');
INSERT INTO State VALUES ('Florida', 'FL');
INSERT INTO State VALUES ('Georgia', 'GA');
INSERT INTO State VALUES ('Hawaii', 'HI');
INSERT INTO State VALUES ('Iowa', 'IA');
INSERT INTO State VALUES ('Idaho', 'ID');
INSERT INTO State VALUES ('Illinois', 'IL');
INSERT INTO State VALUES ('Indiana', 'IN');
INSERT INTO State VALUES ('Kansas', 'KS');
INSERT INTO State VALUES ('Kentucky', 'KY');
INSERT INTO State VALUES ('Louisiana', 'LA');
INSERT INTO State VALUES ('Massachusetts', 'MA');
INSERT INTO State VALUES ('Maryland', 'MD');
INSERT INTO State VALUES ('Maine', 'ME');
INSERT INTO State VALUES ('Michigan', 'MI');
INSERT INTO State VALUES ('Minnesota', 'MN');
INSERT INTO State VALUES ('Missouri', 'MO');
INSERT INTO State VALUES ('Mississippi', 'MS');
INSERT INTO State VALUES ('Montana', 'MT');
INSERT INTO State VALUES ('North Carolina', 'NC');
INSERT INTO State VALUES ('North Dakota', 'ND');
INSERT INTO State VALUES ('Nebraska', 'NE');
INSERT INTO State VALUES ('New Hampshire', 'NH');
INSERT INTO State VALUES ('New Jersey', 'NJ');
INSERT INTO State VALUES ('New Mexico', 'NM');
INSERT INTO State VALUES ('Nevada', 'NV');
INSERT INTO State VALUES ('New York', 'NY');
INSERT INTO State VALUES ('Ohio', 'OH');
INSERT INTO State VALUES ('Oklahoma', 'OK');
INSERT INTO State VALUES ('Oregon', 'OR');
INSERT INTO State VALUES ('Pennsylvania', 'PA');
INSERT INTO State VALUES ('Rhode Island', 'RI');
INSERT INTO State VALUES ('South Carolina', 'SC');
INSERT INTO State VALUES ('South Dakota', 'SD');
INSERT INTO State VALUES ('Tennessee', 'TN');
INSERT INTO State VALUES ('Texas', 'TX');
INSERT INTO State VALUES ('Utah', 'UT');
INSERT INTO State VALUES ('Virginia', 'VA');
INSERT INTO State VALUES ('Vermont', 'VT');
INSERT INTO State VALUES ('Washington', 'WA');
INSERT INTO State VALUES ('Wisconsin', 'WI');
INSERT INTO State VALUES ('West Virginia', 'WV');
INSERT INTO State VALUES ('Wyoming', 'WY');
