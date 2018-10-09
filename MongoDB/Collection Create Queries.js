//insert one record
db.products.insert([{	
	"pid" : 2,
	"pname" : "Orange",
	"price" : 100,
	"quantity" : 15,
	"availability" : "Available",
	"category" : {
		"cid" : "C1",
		"cname" : "Fruits",
		"description" : "Fruits items"
	}
},

{
	"pid" : 3,
	"pname" : "Watermelon",
	"price" : 30,
	"quantity" : 5,
	"availability" : "Out of Stock",
	"category" : {
		"cid" : "C1",
		"cname" : "Fruits",
		"description" : "Fruits items"
	}
}]);

//insert one record
db.products.insertOne({	
	"pid" : 4,
	"pname" : "Tomato",
	"price" : 20,
	"quantity" : 100,
	"availability" : "Available",
	"category" : {
		"cid" : "C2",
		"cname" : "Vegetables",
		"description" : "Vegetable items"
	}
})

//insert multiple records
db.products.insertMany([{	
	"pid" : 1,
	"pname" : "Apple",
	"price" : 200,
	"quantity" : 10,
	"availability" : "Available",
	"category" : {
		"cid" : "C1",
		"cname" : "Fruits",
		"description" : "Fruits items"
	}
},
{	
	"pid" : 2,
	"pname" : "Orange",
	"price" : 100,
	"quantity" : 15,
	"availability" : "Available",
	"category" : {
		"cid" : "C1",
		"cname" : "Fruits",
		"description" : "Fruits items"
	}
},

{
	"pid" : 3,
	"pname" : "Watermelon",
	"price" : 30,
	"quantity" : 5,
	"availability" : "Out of Stock",
	"category" : {
		"cid" : "C1",
		"cname" : "Fruits",
		"description" : "Fruits items"
	}
},

{	
	"pid" : 4,
	"pname" : "Tomato",
	"price" : 20,
	"quantity" : 100,
	"availability" : "Available",
	"category" : {
		"cid" : "C2",
		"cname" : "Vegetables",
		"description" : "Vegetable items"
	}
},

{
	"pid" : 5,
	"pname" : "Brinjal",
	"price" : 25,
	"quantity" : 10,
	"availability" : "Out of Stock",
	"category" : {
		"cid" : "C2",
		"cname" : "Vegetables",
		"description" : "Vegetable items"
	}
},

{	
	"pid" : 6,
	"pname" : "Egg",
	"price" : 5,
	"quantity" : 20,
	"availability" : "Available",
	"category" : {
		"cid" : "C3",
		"cname" : "Food",
		"description" : "Food items"
	}
},

{
	"pid" : 7,
	"pname" : "Wheat",
	"price" : 45,
	"quantity" : 25,
	"availability" : "Out of Stock",
	"category" : {
		"cid" : "C3",
		"cname" : "Food",
		"description" : "Food items"
	}
},

{
	"pid" : 8,
	"pname" : "HP Envy",
	"price" : 75000,
	"quantity" : 5,
	"availability" : "Out of Stock",
	"category" : {
		"cid" : "C4",
		"cname" : "Gadgets",
		"description" : "Laptops and mobiles"
	}
},

{
	"pid" : 9,
	"pname" : "Honor 9 Lite",
	"price" : 19999,
	"quantity" : 5,
	"availability" : "Available",
	"category" : {
		"cid" : "C4",
		"cname" : "Gadgets",
		"description" : "Laptops and mobiles"
	}
},

{
	"pid" : 10,
	"pname" : "Iphone X",
	"price" : 86000,
	"quantity" : 2,
	"availability" : "Out of Stock",
	"category" : {
		"cid" : "C4",
		"cname" : "Gadgets",
		"description" : "Laptops and mobiles"
	}
}])

//insert single 
db.products.save({
	"pid" : 7,
	"pname" : "Wheat Grass",
	"price" : 45,
	"quantity" : 25,
	"availability" : "Out of Stock",
	"category" : {
		"cid" : "C3",
		"cname" : "Food",
		"description" : "Food items"
	}
});

//insert multiple
db.products.save([{
	"pid" : 8,
	"pname" : "HP Envy",
	"price" : 75000,
	"quantity" : 5,
	"availability" : "Out of Stock",
	"category" : {
		"cid" : "C4",
		"cname" : "Gadgets",
		"description" : "Laptops and mobiles"
	}
},

{
	"pid" : 9,
	"pname" : "Honor 9 Lite",
	"price" : 19999,
	"quantity" : 5,
	"availability" : "Available",
	"category" : {
		"cid" : "C4",
		"cname" : "Gadgets",
		"description" : "Laptops and mobiles"
	}
},

{
	"pid" : 10,
	"pname" : "Iphone X",
	"price" : 86000,
	"quantity" : 2,
	"availability" : "Out of Stock",
	"category" : {
		"cid" : "C4",
		"cname" : "Gadgets",
		"description" : "Laptops and mobiles"
	}
}])

db.products.update({_id:ObjectID("5ba87b5a220decdb09319d98")},
{$set:{
    pid:1,
    pname:"Apple",
    availability:"Available"
},$unset: {
    id: "1", 
    name:"Apple"
}})

ObjectId("5ba87b5a220decdb09319d98")

db.products.updateMany({
    availability:"Out of Stock"
},
{
    $set:{
        quantity:0
    }
})

db.products.remove({availability:"Out of Stock"})

db.products.drop()

