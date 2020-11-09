class Box<T>{
    private _boxes: T[] = [];

    public add(el: T){
        this._boxes.push(el);
    }

    public remove(){
        this._boxes.pop();
    }

    get count(): number{
        return this._boxes.length;
    }
}

let firstBox = new Box<Number>();

firstBox.add(1);
firstBox.add(2);
firstBox.add(3);

console.log(firstBox.count);

let secondBox = new Box<String>();

secondBox.add("Pesho");
secondBox.add("Gosho");
console.log(secondBox.count);

secondBox.remove();
console.log(secondBox.count);
