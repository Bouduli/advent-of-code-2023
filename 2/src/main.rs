use std::{fs, vec};

fn main() {
    println!("Hello, world!");

    // fs::read_to_string("src/aoc2_test");
    let input: String = fs::read_to_string("src/aoc2_input").unwrap();
    let lines =input.lines();
    
    for s in lines{
        lookAtString(s);
    }

    // println!("{}",input);
}

fn lookAtString(string: &str)->bool{
    let game: &str = string.split(": ").nth(1).unwrap();

    let games: Vec<&str> = game.split(";").into_iter().collect();
    print!("{:?}", games);


    false
}