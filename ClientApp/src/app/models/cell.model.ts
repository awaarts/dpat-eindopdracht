class Cell {
  constructor(value?: number, helperValues? : number[], state?: string, x?: number, y?: number) {
    this.value = value;
    this.helperValues = helperValues;
    this.state = state;
    this.x = x;
    this.y = y;
  }
  public value? : number;
  helperValues? : number[];
  state? : string = 'empty';
  x? : number;
  y? : number;

}

export { Cell };
