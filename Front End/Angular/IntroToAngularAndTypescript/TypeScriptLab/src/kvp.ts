class KeyValuePair<TKey, TValue>{
    private key: TKey;
    private value: TValue;

    public setKeyValue(key: TKey, value: TValue) {
        this.key = key;
        this.value = value;
    }

    public display(){
        console.log(`key = ${this.key}, value = ${this.value}`);
    }
}

let kvp = new KeyValuePair<number, string>();

kvp.setKeyValue(1, "Steve");

kvp.display();
