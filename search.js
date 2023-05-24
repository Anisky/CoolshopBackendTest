const fs = require('fs');

// Checking if command line arguments are provided correctly
if (process.argv.length != 5) { 
    console.log("\nWrong arguments entered!!\n");
    console.log("------ Utilization------\n node search.js <file_path> <column_number> <search_key>");
    process.exit(1);
}

const filePath = process.argv[2];
const columnNumber = parseInt(process.argv[3]);
const searchKey = process.argv[4];

try {
    // Read the CSV file
    const rows = fs.readFileSync(filePath, 'utf8').split('\n');
    // Search for matching records
    const result = rows.find(row => row.split(',')[columnNumber].trim() === searchKey);

     
    console.log("-----Search Result ------")
    
    if (result) {
        console.log(result);// Output matching records 
    } else {
    
        console.log("No records matching the search critera were found.");
    }

} catch (err) {

    console.log("-----Error------")
    console.log(`An error has been encountered: ${err.message}`);
} 