#include <tools.h>

void Tools::MsgBox(QString txt) {
    QMessageBox *msgBox = new QMessageBox(0);
    msgBox->setText(txt);
    msgBox->exec();
}

inline const char * const BoolToString(bool b)
{
  return b ? "true" : "false";
}

void Tools::launchApp(QString folder, QString file) {
    QString str = QDir::toNativeSeparators(folder + "/" + file);
    bool rsl = QProcess::startDetached(str);
    if (!rsl) {
        this->MsgBox("Failed to open:\n"+str);
    }
}

void Tools::zip(QString filename , QString zip_filename)
{
   QFile infile(filename);
   QFile outfile(zip_filename);
   infile.open(QIODevice::ReadOnly);
   outfile.open(QIODevice::WriteOnly);
   QByteArray uncompressed_data = infile.readAll();
   QByteArray compressed_data = qCompress(uncompressed_data, 9);
   outfile.write(compressed_data);
   infile.close();
   outfile.close();
}

void Tools::unZip(QString zip_filename , QString filename)
{
   QFile infile(zip_filename);
   QFile outfile(filename);
   infile.open(QIODevice::ReadOnly);
   outfile.open(QIODevice::WriteOnly);
   QByteArray uncompressed_data = infile.readAll();
   QByteArray compressed_data = qUncompress(uncompressed_data);
   outfile.write(compressed_data);
   infile.close();
   outfile.close();
}

QString Tools::OpenExplorer(QString path) {
    QString dirLoc = QFileDialog::getExistingDirectory(0, QObject::tr("Open Directory"),
        path,
        QFileDialog::ShowDirsOnly | QFileDialog::DontResolveSymlinks);
    return QDir::toNativeSeparators(dirLoc);
}
