using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Frontend2;
using Frontend2.Parser;

public class ScriptProcessor {
    VendingMachineParser parser;
    SENG301VMAnalyzer analyzer;

    public ScriptProcessor(TextReader reader, IVendingMachineFactory factory) {
        this.analyzer = new SENG301VMAnalyzer();
        this.analyzer.RegisterVendingMachineFactory(factory);
        this.parser = new VendingMachineParser(reader, this.analyzer);
    }

    public ScriptProcessor(string pathToScript, IVendingMachineFactory factory) :
        this(new StreamReader(File.OpenRead(pathToScript)), factory) {
    }

    public void Parse() {
        this.parser.Parse();
    }
    
    public static void Main(string[] args) {
        var testDir = "test-scripts"; // THIS MIGHT BE "tests" or "test"
        var testToGrade = new Dictionary<string, double>() {
            { testDir + "\\" + "T01-good-script", 10 },
            { testDir + "\\" + "T01-good-insert-and-press-exact-change", 10 },
            { testDir + "\\" + "T02-good-insert-and-press-change-expected", 8 },
            { testDir + "\\" + "T03-good-teardown-without-configure-or-load", 6},
            { testDir + "\\" + "T04-good-press-without-insert", 4 },
            { testDir + "\\" + "T05-good-scrambled-coin-kinds", 4 },
            { testDir + "\\" + "T06-good-extract-before-sale", 2 },
            { testDir + "\\" + "T07-good-changing-configuration", 1 },
            { testDir + "\\" + "T08-good-approximate-change", 0.5 },
            { testDir + "\\" + "T09-good-hard-for-change", 0.25 },
            { testDir + "\\" + "T10-good-invalid-coin", 2},
            { testDir + "\\" + "T11-good-extract-before-sale-complex", 0.5 },
            { testDir + "\\" + "T12-good-approximate-change-with-credit", 0.5 },
            { testDir + "\\" + "U01-bad-configure-before-construct", 3 },
            { testDir + "\\" + "U01-bad-script1", 10 },
            { testDir + "\\" + "U02-bad-script2", 10 },
            { testDir + "\\" + "U02-bad-costs-list", 2 },
            { testDir + "\\" + "U03-bad-names-list", 2 },
            { testDir + "\\" + "U04-bad-non-unique-denomination", 2 },
            { testDir + "\\" + "U05-bad-coin-kind", 1 },
            { testDir + "\\" + "U06-bad-button-number", 1 },
            { testDir + "\\" + "U07-bad-button-number-2", 1 },
            { testDir + "\\" + "U08-bad-button-number-3", 1 }
        };
        double cumulativeScore = 0;
        double maxScore = testToGrade.Sum(kv => kv.Value);

        var goodScripts = Directory.GetFiles(testDir, "T*");
        foreach (var script in goodScripts) {
            var pass = true;
            Console.Write(script + ":");
            try {
                var scriptParser = new ScriptProcessor(new StreamReader(File.OpenRead(script)), new VendingMachineFactory());
                scriptParser.Parse();
            }
            catch {
                pass = false;
            }
            Console.WriteLine(pass ? " PASS=Good" : " FAIL=Bad");
            if (pass) {
                if (testToGrade.ContainsKey(script)) {
                    cumulativeScore += testToGrade[script];
                }
                else {
                    Console.WriteLine("Test {0} does not have a value", script);
                }
            }
        }
        var badScripts = Directory.GetFiles(testDir, "U*");
        foreach (var script in badScripts) {
            var pass = true;
            Console.Write(script + ":");
            try {
                var scriptParser = new ScriptProcessor(new StreamReader(File.OpenRead(script)), new VendingMachineFactory());
                scriptParser.Parse();
            }
            catch {
                pass = false;
            }
            Console.WriteLine(pass ? " PASS=Bad" : " FAIL=Good");
            if (!pass) {
                if (testToGrade.ContainsKey(script)) {
                    cumulativeScore += testToGrade[script];
                }
                else {
                    Console.WriteLine("Test {0} does not have a value", script);
                }
            }
        }

        Console.WriteLine("{0}/{1}", cumulativeScore, maxScore);
    }
}
