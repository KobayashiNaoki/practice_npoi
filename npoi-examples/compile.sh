#/bin/bash

if [ $# != 2 ]; then
    echo "引数に以下のファイルを指定"
    echo " .csファイル"
    echo " .exeファイル"
    echo "例: bash compile.sh create_excel.cs create_excel.exe"
    exit
fi
if [ ! -e $1 ]; then
   echo $1 "というファイルが存在しない"
   exit
fi

SCRIPT_FILE=$1
EXE_FILE=$2

PACKAGE_DIR=../packages  # nugetで指定したディレクトリ
# 使用するライブラリ (スペース区切りで複数指定可)
PACKAGE_NAMES="NPOI.2.5.2/lib/net45 System.Text.Json.5.0.0/lib/net461 System.Text.Encodings.Web.5.0.0/lib/net461 System.Memory.4.5.4/lib/net461 System.Numerics.Vectors.4.5.0/lib/net46 System.Threading.Tasks.Extensions.4.5.4/lib/net461 System.Threading.Tasks.Extensions.4.5.4/lib System.ValueTuple.4.5.0/lib/net461 System.Buffers.4.5.1/lib/net461 Microsoft.Bcl.AsyncInterfaces.5.0.0/lib/net461 System.Runtime.CompilerServices.Unsafe.5.0.0/lib/net45"


##
# PACKAGE_NAMESに内包される.dllファイルをreferenceに追加
##
echo "# refferd dll file:"
PATH_TO_DLL=""  # .dllファイルを保持する変数
for name in $PACKAGE_NAMES ; do
    # .dllファイルを検索
    dll_files=`find $PACKAGE_DIR/$name | grep .dll`
    
    # PATH_TO_DLLにdllファイルのpathを追加
    for file_path in $dll_files; do
        echo "# -" $file_path
        PATH_TO_DLL=$file_path,$PATH_TO_DLL
    done
done
echo $PATH_TO_DLL
echo ""

##
# コンパイル
##
echo "# compile by mcs"
echo "# exec command: mcs /reference:$PATH_TO_DLL /out:$EXE_FILE $SCRIPT_FILE"
mcs -nowarn /reference:$PATH_TO_DLL /out:$EXE_FILE $SCRIPT_FILE
compile_state=$? #直前のプロセス(コンパイル)の終了状態
echo ""


##
# MONO_PATHへと追記
##
for name in $PACKAGE_NAMES ; do
    MONO_PATH=$PACKAGE_DIR/$name:$MONO_PATH
done
echo $MONO_PATH

##
# 実行
##
if [ $compile_state = 0 ] ; then
    echo "# run exe file"
    echo "# exec command: MONO_PATH=$MONO_PATH mono $EXE_FILE"
    # monoで実行する際に必要なPATH
    MONO_PATH=$MONO_PATH mono $EXE_FILE
fi
