#ifndef DOWNLOADER_H
#define DOWNLOADER_H

#include <mainwindow.h>

class Downloader : public QObject
{
    Q_OBJECT
    public:
        void doDownload(QString _url);

    public slots:
        void replyFinished (QNetworkReply *reply);

    private:
        QNetworkAccessManager *manager;

};

#endif // DOWNLOADER_H
