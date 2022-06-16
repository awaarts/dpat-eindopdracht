class Cell {
  constructor(value?: number, notes? : number[], state?: string, x?: number, y?: number) {
    this.value = value;
    this.notes = notes;
    this.state = state;
    this.x = x;
    this.y = y;
  }
  public value? : number;
  notes? : number[];
  state? : string = 'empty';
  x? : number;
  y? : number;

}

export { Cell };
