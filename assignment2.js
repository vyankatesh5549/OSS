var exp=require('express');

var app=exp();

app.get('/home',function(req,res){
	res.send("<h1> Welcome to web app</h1>");
});

app.listen(9000,function(){
	console.log("exp sever started at 9000");
});