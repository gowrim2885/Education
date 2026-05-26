//get and set the data from the local storage

class DataContext{
    getData(){
        let data = JSON.parse(localStorage.getItem("Students"))||[];
        return data;
    }
    setData(content){
        localStorage.setItem("Students",JSON.stringify(content));
    }
}
