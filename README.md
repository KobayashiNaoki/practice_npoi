# NPOI 使い方
[NPOI Github](https://github.com/nissl-lab/npoi)


## C\#のプログラムを動かす
mcsはコンパイラ
monoはランタイム
ソースファイルの拡張子はcs

    mcs Program.cs
    mono Program.exe
    
    
## NPOIのインストール
packagesディレクトリが作成され，その中にNPOIがインストールされる
    
    nuget install npoi -OutputDirectory packages


## サンプル
[サンプル Github](https://github.com/nissl-lab/npoi-examples)

以下のディレクトリにexcel, wordそれぞれのサンプルがある．
[xssf ディレクトリ :](https://github.com/nissl-lab/npoi-examples/tree/main/xssf) Excel 2007 (xlsx)
[wxpf ディレクトリ](https://github.com/nissl-lab/npoi-examples/tree/main/xwpf) : Word 2007 (docx)


## サンプルの動かし方
    
    cd npoi-examples
    bash compile.sh create_excel.cs create_excel.exe
    bash compile.sh write_cell.cs write_cell.exe
