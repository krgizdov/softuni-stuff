abstract class Melon {
    protected elementType: string;
    private elementIndex: number;

    constructor(public weight: number, public melonSort: string) {
        this.elementIndex = weight * melonSort.length;
    }

    getElementIndex(): number {
        return this.elementIndex;
    }

    toString(): string {
        return `Element: ${this.elementType}\r\nSort: ${this.melonSort}\r\nElement Index: ${this.getElementIndex()}`;
    }

    getElementType(){
        console.log(this.elementType);
    }
}

class Watermelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.elementType = "Water";
    }
}

class Firemelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.elementType = "Fire";
    }
}

class Airmelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.elementType = "Air";
    }
}

class Earthmelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.elementType = "Earth";
    }
}

class Melolemonmelon extends Watermelon {
    private types: string[] = [];
    
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.types.push("Fire");
        this.types.push("Earth");
        this.types.push("Air");
        this.types.push("Water");
    }

    public morph() {
        const currentType = this.types.shift();
        this.elementType = currentType;
        this.types.push(currentType);
    }
}

let watermelon : Melolemonmelon = new Melolemonmelon(12.5, "Kingsize");
console.log(watermelon.toString());
watermelon.morph();
console.log(watermelon.toString());
watermelon.morph();
console.log(watermelon.toString());
watermelon.morph();
console.log(watermelon.toString());
watermelon.morph();
console.log(watermelon.toString());